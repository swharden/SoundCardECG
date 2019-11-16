using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoundCardECG
{
    public partial class FormMain : Form
    {

        private ECG ecg;

        public FormMain()
        {
            InitializeComponent();
            enabledToolStripMenuItem_Click(null, null); // disable heartbeat detection by default
            StyleGraphs();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            SelectSoundCard();
            StartListening();
            Version ver = typeof(FormAbout).Assembly.GetName().Version;
            Text = $"Sound Card ECG {ver.Major}.{ver.Minor}";
        }

        private void SelectSoundCard()
        {
            using (FormSoundCard frm = new FormSoundCard())
            {
                frm.ShowDialog();
                deviceNumber = frm.deviceNumber;
            }

            if (deviceNumber < 0)
                MessageBox.Show("No input device was selected, so nothing will be graphed.", "ERROR");
            else
                StartListening();
        }

        public int deviceNumber = 1;
        private void StartListening()
        {
            // stop the old listener if it's running
            if (ecg != null)
                ecg.Stop();

            // start a new listener
            ecg = new ECG(deviceNumber);
            ecg.beatThreshold = (int)nudThreshold.Value;

            while (ecg.values == null)
                System.Threading.Thread.Sleep(10);

            scottPlotUC1.plt.Clear();
            scottPlotUC1.plt.PlotSignal(ecg.values, ecg.SAMPLERATE, color: ColorTranslator.FromHtml("#d62728"));
            fullScaleToolStripMenuItem_Click(null, null);
            timerRenderGraph.Enabled = true;
        }

        #region graphing

        private void StyleGraphs()
        {
            scottPlotUC1.plt.YLabel("Signal (PCM)");
            scottPlotUC1.plt.XLabel("Time (seconds)");
            scottPlotUC1.plt.Title("Sound Card ECG Signal");
            scottPlotUC1.Render();

            scottPlotUC2.plt.YLabel("Heart Rate (BPM)");
            scottPlotUC2.plt.XLabel("Time (seconds)");
            scottPlotUC2.plt.Title("Heart Beat Detection");
        }

        bool busyRendering = false;
        bool useLowpassFiltering = false;
        private void timerRenderGraph_Tick(object sender, EventArgs e)
        {
            if (busyRendering)
                return;

            busyRendering = true;

            // update the ECG waveform trace
            if (useLowpassFiltering)
            {
                scottPlotUC1.plt.Clear();
                scottPlotUC1.plt.PlotSignal(ecg.GetFilteredValues(), ecg.SAMPLERATE);
                scottPlotUC1.Render();
            }
            else
            {
                scottPlotUC1.plt.Clear(signalPlots: false);
                scottPlotUC1.plt.PlotVLine((double)ecg.lastPointUpdated / ecg.SAMPLERATE, color: ColorTranslator.FromHtml("#636363"));
                if (displayHeartbeats)
                    scottPlotUC1.plt.PlotHLine(ecg.beatThreshold, color: ColorTranslator.FromHtml("#bcbd22"));
                scottPlotUC1.Render();
            }

            // create a new BPM trace from scratch
            if (displayHeartbeats && ecg.beatTimes != null && ecg.beatTimes.Count > 0)
            {
                scottPlotUC2.plt.Clear();
                scottPlotUC2.plt.PlotScatter(ecg.beatTimes.ToArray(), ecg.beatRates.ToArray());
                if (cbAutoscale.Checked)
                    scottPlotUC2.plt.AxisAuto();
                lblBmp.Text = string.Format("{0:0.0} BPM", ecg.beatRates[ecg.beatRates.Count - 1]);
                scottPlotUC2.Render();
            }

            Application.DoEvents();
            busyRendering = false;
        }

        #endregion

        #region GUI bindings

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectSoundCard();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void documentationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/swharden/SoundCardECG");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormAbout frm = new FormAbout())
                frm.ShowDialog();
        }

        private bool displayHeartbeats = false;
        private void enabledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (enabledToolStripMenuItem.Checked)
            {
                displayHeartbeats = true;
                Height = 766;
            }
            else
            {
                displayHeartbeats = false;
                Height = 438;
            }
            Console.WriteLine($"Heartbeat detection: {displayHeartbeats}");
        }

        private void autoscalemiddleclickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scottPlotUC1.plt.AxisAuto();
            scottPlotUC1.Render();
        }

        private void fullScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scottPlotUC1.plt.AxisAuto();
            scottPlotUC1.plt.Axis(y1: -Math.Pow(2, 16) / 2, y2: Math.Pow(2, 16) / 2);
            scottPlotUC1.Render();
        }

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = "Sound Card ECG.png";
            savefile.Filter = "PNG Files (*.png)|*.png|All files (*.*)|*.*";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                string saveFilePath = savefile.FileName;
                scottPlotUC1.plt.SaveFig(saveFilePath);
            }
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ecg.Stop();
            timerRenderGraph.Enabled = false;
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartListening();
        }

        private void nudThreshold_ValueChanged(object sender, EventArgs e)
        {
            ecg.beatThreshold = (int)nudThreshold.Value;
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartListening();
        }

        private void saveCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = "Sound Card ECG.csv";
            savefile.Filter = "CSV Files (*.csv)|*.csv|All files (*.*)|*.*";
            if (savefile.ShowDialog() == DialogResult.OK)
                System.IO.File.WriteAllText(savefile.FileName, ecg.GetCSV());
        }

        #endregion

        private void invertSignalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (invertSignalToolStripMenuItem.Checked)
                ecg.signalMultiple = -1;
            else
                ecg.signalMultiple = 1;
        }
    }
}
