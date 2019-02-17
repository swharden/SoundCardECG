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

            scottPlotUC1.plt.settings.figureBgColor = SystemColors.Control;
            scottPlotUC1.plt.settings.axisLabelY = "Signal (PCM)";
            scottPlotUC1.plt.settings.axisLabelX = "Time (seconds)";
            scottPlotUC1.plt.settings.title = "ECG Signal";

            scottPlotUC2.plt.settings.figureBgColor = SystemColors.Control;
            scottPlotUC2.plt.settings.axisLabelY = "Heart Rate (BPM)";
            scottPlotUC2.plt.settings.axisLabelX = "Time (seconds)";
            scottPlotUC2.plt.settings.title = "Heart Beat Detection";
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //SelectSoundCard();
            StartListening(0);
        }

        private void StartListening(int deviceNumber)
        {
            ecg = new ECG(deviceNumber);
            while (ecg.values == null)
                System.Threading.Thread.Sleep(10);

            scottPlotUC1.plt.data.Clear();
            scottPlotUC1.plt.data.AddSignal(ecg.values, ecg.SAMPLERATE);
            scottPlotUC1.plt.data.AddHorizLine(ecg.beatThreshold);

            timer1.Enabled = true;
        }

        private void SelectSoundCard()
        {
            int deviceNumber;

            using (FormSoundCard frm = new FormSoundCard())
            {
                frm.ShowDialog();
                deviceNumber = frm.deviceNumber;
            }

            if (deviceNumber < 0)
                MessageBox.Show("No input device was selected, so nothing will be graphed.", "ERROR");
            else
                StartListening(deviceNumber);
        }

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

        bool busyRendering = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (busyRendering)
                return;

            busyRendering = true;

            // update the ECG waveform trace
            scottPlotUC1.Render();

            // create a new BPM trace from scratch
            if (ecg.beatTimes != null && ecg.beatTimes.Count > 0)
            {
                scottPlotUC2.plt.data.Clear();
                scottPlotUC2.plt.data.AddScatter(ecg.beatTimes.ToArray(), ecg.beatRates.ToArray());
                scottPlotUC2.plt.settings.AxisFit();
                scottPlotUC2.Render();
                lblBmp.Text = string.Format("{0:0.0} BPM", ecg.beatRates[ecg.beatRates.Count - 1]);
            }

            Application.DoEvents();
            busyRendering = false;
        }
    }
}
