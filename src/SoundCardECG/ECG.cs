using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundCardECG
{
    public class ECG
    {
        public int SAMPLERATE = 8000;
        int BITRATE = 16;
        int CHANNELS = 1;
        int BUFFERMILLISEC = 20;
        int STORESECONDS = 5;
        int bufferIndex = 0;
        int buffersCaptured = 0;
        public int beatThreshold = 3500;
        public double signalMultiple = 1;

        public List<double> beatTimes = new List<double>();
        public List<double> beatRates = new List<double>();

        NAudio.Wave.WaveInEvent wvin;

        public double[] values;
        public double[] times;

        public ECG(int deviceNumber)
        {
            Console.WriteLine($"Preparing audio device: {deviceNumber}");
            wvin = new NAudio.Wave.WaveInEvent();
            wvin.DeviceNumber = deviceNumber;
            wvin.WaveFormat = new NAudio.Wave.WaveFormat(SAMPLERATE, BITRATE, CHANNELS);
            wvin.BufferMilliseconds = BUFFERMILLISEC;
            wvin.DataAvailable += OnDataAvailable;
            Start();
        }

        public void Start()
        {
            Console.WriteLine($"Starting recording...");
            wvin.StartRecording();
        }

        public void Stop()
        {
            wvin.StopRecording();
            Console.WriteLine($"Recording stopped.");
        }

        public double[] GetFilteredValues()
        {
            double[] chrono = new double[values.Length];
            for (int i = 0; i < lastPointUpdated; i++)
                chrono[values.Length - lastPointUpdated + i] = values[i];
            for (int i = lastPointUpdated; i < values.Length; i++)
                chrono[i - lastPointUpdated] = values[i];
            chrono = LowPassFilter(chrono);
            return chrono;
        }

        private double[] LowPassFilter(double[] pcm, double cutOffFrequency = 500, double sampleRate = 8000)
        {
            // it really should be a power of 2
            int fft_size = pcm.Length;

            // create a complex data object we will use to shuffle data around
            MathNet.Numerics.Complex32[] complex = new MathNet.Numerics.Complex32[fft_size];

            // prepare the windowing function
            int windowSize = 1000;
            double[] window = new double[pcm.Length];
            for (int i = 0; i < window.Length; i++)
            {
                if (i < windowSize)
                {
                    int distanceFromEdge = i;
                    window[i] = (double)distanceFromEdge / windowSize;
                }
                else if (i > window.Length - windowSize)
                {
                    int distanceFromEdge = window.Length - i;
                    window[i] = (double)distanceFromEdge / windowSize;
                }
                else
                {
                    window[i] = 1;
                }
            }

            // load original PCM data into the complex array
            for (int i = 0; i < fft_size; i++)
            {
                float val = (float)(pcm[i] * window[i]);
                complex[i] = new MathNet.Numerics.Complex32(val, 0);
            }

            // perform the forward FFT
            MathNet.Numerics.IntegralTransforms.Fourier.Forward(complex);

            // blank-out the high frequency stuff
            for (int i = 0; i < fft_size / 2; i++)
            {
                double freq = (double)(i * sampleRate * 2) / fft_size;
                if (i == fft_size / 2 - 1) System.Console.WriteLine(freq);
                if (freq < cutOffFrequency) continue;
                complex[i] = new MathNet.Numerics.Complex32(0, 0);
                complex[fft_size - i - 1] = new MathNet.Numerics.Complex32(0, 0);
            }

            // perform the inverse FFT
            MathNet.Numerics.IntegralTransforms.Fourier.Inverse(complex);

            // extract the real component into the original PCM array and return it
            for (int i = 0; i < fft_size; i++) pcm[i] = complex[i].Real;

            return pcm;
        }

        private void BeatDetected(double timeSec)
        {
            double beatRate = 0;
            if (beatTimes.Count > 0)
            {
                double beatToBeatTime = timeSec - beatTimes[beatTimes.Count - 1];
                beatRate = 1.0 / beatToBeatTime * 60;
                if (beatRate > 250)
                    return;
            }
            beatTimes.Add(timeSec);
            beatRates.Add(beatRate);

            // fix the first heartbeat which lacks a BPM
            if (beatRates.Count > 0 && beatRates[0] == 0)
                beatRates[0] = beatRate;

            Console.WriteLine($"BEAT at {timeSec} sec ({Math.Round(beatRate, 1)} BPM)");
        }

        public int lastPointUpdated = 0;
        private void OnDataAvailable(object sender, NAudio.Wave.WaveInEventArgs args)
        {
            // convert from a 16-bit byte array to a double array
            int bytesPerValue = BITRATE / 8;
            int valuesInBuffer = args.BytesRecorded / bytesPerValue;
            double[] bufferValues = new double[valuesInBuffer];
            for (int i = 0; i < valuesInBuffer; i++)
                bufferValues[i] = BitConverter.ToInt16(args.Buffer, i * bytesPerValue) * signalMultiple;

            // determine if a heartbeat occured
            int j = 0;
            while (j < bufferValues.Length)
            {
                if (bufferValues[j] > beatThreshold)
                {
                    int beatSampleNumber = j + buffersCaptured * valuesInBuffer;
                    double beatTimeSec = (double)beatSampleNumber / SAMPLERATE;
                    BeatDetected(beatTimeSec);
                    break;
                }
                j++;
            }

            // create the values buffer if it does not exist
            if (values == null)
            {
                int idealSampleCount = STORESECONDS * SAMPLERATE;
                int bufferCount = idealSampleCount / valuesInBuffer;
                values = new double[bufferCount * valuesInBuffer];
                times = new double[bufferCount * valuesInBuffer];
                for (int i = 0; i < times.Length; i++)
                    times[i] = (double)i / SAMPLERATE;
            }

            // copy these data into the correct place of the larger buffer
            Array.Copy(bufferValues, 0, values, bufferIndex * valuesInBuffer, bufferValues.Length);
            lastPointUpdated = bufferIndex * valuesInBuffer + bufferValues.Length;

            // update counts
            buffersCaptured += 1;
            bufferIndex += 1;
            if (bufferIndex * valuesInBuffer > values.Length - 1)
                bufferIndex = 0;
        }

        public string GetCSV()
        {
            string csv = "beat, time (s), rate (bpm)\n";
            for (int i = 0; i < beatTimes.Count; i++)
                csv += $"{i + 1}, {Math.Round(beatTimes[i], 3)}, {Math.Round(beatRates[i], 3)}\n";
            return csv;
        }
    }
}
