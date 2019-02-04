using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundCardECG
{
    public class SWHear
    {
        private WaveInEvent wvin;

        public readonly int deviceIndex;
        public readonly int sampleRate;
        public readonly int bitRate;
        public readonly int channels;
        public readonly int bufferMilliseconds;
        public readonly int bufferSampleCount;
        public readonly int bytesPerSample;
        public readonly int pcmDataPointCount;
        public readonly int dataBufferCount; // how many buffers are saved in the PCM data

        private int nextBufferToFill = 0;

        public int buffersRead { get; private set; }

        public double[] bufferSingle;
        public double[] pcmDataCircular;
        public double[] amplitudesByBuffer;

        public SWHear(int deviceIndex, int sampleRate = 8000, int bitRate = 16, int channels = 1, int bufferMilliseconds = 20, int dataBufferCount = 210)
        {

            // note: I adjusted the buffer count to slightly exceed a power of 2.

            // assign class properties
            this.deviceIndex = deviceIndex;
            this.sampleRate = sampleRate;
            this.bitRate = bitRate;
            this.channels = channels;
            this.bufferMilliseconds = bufferMilliseconds;
            this.dataBufferCount = dataBufferCount;

            // extra calculations
            double pointsPerMsec = (double)sampleRate / 1000;
            bufferSampleCount = (int)(pointsPerMsec * bufferMilliseconds);
            pcmDataPointCount = bufferSampleCount * dataBufferCount;
            if (bitRate == 8)
                bytesPerSample = 1;
            else if (bitRate == 16)
                bytesPerSample = 2;
            else
                throw new Exception($"Bit depth unsupported ({bitRate}-bit)");

            // set aside memory for our buffers
            bufferSingle = new double[bufferSampleCount];
            pcmDataCircular = new double[pcmDataPointCount];
            amplitudesByBuffer = new double[dataBufferCount];

            // open the audio device
            wvin = new WaveInEvent();
            wvin.DeviceNumber = deviceIndex;
            wvin.WaveFormat = new NAudio.Wave.WaveFormat(sampleRate, bitRate, channels);
            wvin.DataAvailable += OnDataAvailable;
            wvin.BufferMilliseconds = bufferMilliseconds;
        }

        public string GetStats()
        {
            string msg = "";
            msg += $"device index: {deviceIndex}\n";
            msg += $"sample rate: {sampleRate}\n";
            msg += $"bit depth: {bitRate}\n";
            msg += $"channels: {channels}\n";
            msg += $"buffer duration: {bufferMilliseconds} ms\n";
            msg += $"buffer points: {bufferSampleCount} ms\n";
            msg += $"buffers read: {buffersRead} ({buffersRead * bufferMilliseconds / 1000.0} sec)\n";
            msg += $"buffers to keep: {dataBufferCount} ({dataBufferCount * bufferMilliseconds / 1000.0} sec)\n";
            msg += $"next buffer to fill: {nextBufferToFill}\n";
            msg += $"pcm size (points): {pcmDataPointCount}\n";
            msg += $"pcm size (sec): {(double)pcmDataPointCount / sampleRate}\n";
            return msg.Replace("\n", "\r\n");
        }

        public void Start()
        {
            wvin.StartRecording();
        }

        public void Stop()
        {
            wvin.StopRecording();
        }

        private void OnDataAvailable(object sender, WaveInEventArgs args)
        {
            for (int i = 0; i < bufferSampleCount; i++)
                bufferSingle[i] = BitConverter.ToInt16(args.Buffer, i * bytesPerSample);
            double amplitude = bufferSingle.Max() - bufferSingle.Min();
            amplitudesByBuffer[nextBufferToFill] = amplitude;
            bufferSingle.CopyTo(pcmDataCircular, nextBufferToFill * bufferSampleCount);
            nextBufferToFill += 1;
            if (nextBufferToFill == dataBufferCount)
                nextBufferToFill = 0;
            buffersRead += 1;
        }

        public double[] GetLinearPcmData()
        {
            int indexSplit = nextBufferToFill * bufferSampleCount;
            double[] data = new double[pcmDataCircular.Length];
            for (int i = 0; i < indexSplit; i++)
                data[pcmDataCircular.Length - indexSplit + i] = pcmDataCircular[i];
            for (int i = 0; i < data.Length - indexSplit; i++)
                data[i] = pcmDataCircular[i + indexSplit];
            return data;
        }

        public double[] LowPassFilter(double[] pcm, double cutOffFrequency = 60)
        {
            // it really should be a power of 2
            int fftSize = pcm.Length;

            MathNet.Numerics.Complex32[] complex = new MathNet.Numerics.Complex32[fftSize];

            // load original PCM data into the complex array
            for (int i = 0; i < fftSize; i++)
            {
                //float val = (float)(pcm[i] * NAudio.Dsp.FastFourierTransform.HammingWindow(i, pcm.Length));
                float val = (float)(pcm[i]);
                complex[i] = new MathNet.Numerics.Complex32(val, 0);
            }

            // perform the forward FFT
            MathNet.Numerics.IntegralTransforms.Fourier.Forward(complex);

            // blank-out the high frequency stuff
            for (int i = 0; i < fftSize / 2; i++)
            {
                double freq = (double)(i * sampleRate * 2) / fftSize;
                if (freq < cutOffFrequency)
                    continue;
                complex[i] = new MathNet.Numerics.Complex32(0, 0);
                complex[fftSize - i - 1] = complex[i];
            }

            // perform the inverse FFT
            MathNet.Numerics.IntegralTransforms.Fourier.Inverse(complex);

            // extract the real component into the original PCM array and return it
            for (int i = 0; i < fftSize; i++)
                pcm[i] = complex[i].Real;

            return pcm;
        }
    }
}
