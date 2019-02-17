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
                bufferValues[i] = BitConverter.ToInt16(args.Buffer, i * bytesPerValue);

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
