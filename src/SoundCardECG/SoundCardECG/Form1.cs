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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DeviceOpen();
            DeviceStart();
        }

        public void LaunchMicrophoneControlPanel()
        {
            var controlPanelPath = System.IO.Path.Combine(Environment.SystemDirectory, "control.exe");
            System.Diagnostics.Process.Start(controlPanelPath, "mmsys.cpl");
        }

        public SWHear swhear;
        public double[] pcmLinear;
        public void DeviceOpen()
        {
            // init the device
            swhear = new SWHear(0);

            // launch the debug window
            Form frmDebug = new FormDebug(swhear);
            frmDebug.Show();
        }

        public void DeviceStart()
        {
            swhear.Start();
            timer1.Enabled = true;
        }

        public void DeviceStop()
        {
            swhear.Stop();
            timer1.Enabled = false;
        }

        ////////////////////////////////////////////////////////////////////////////////
        // GUI BINDINGS

        private void microphoneControlsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchMicrophoneControlPanel();
        }

        int lastBufferPlotted;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (swhear != null && swhear.buffersRead != lastBufferPlotted)
            {
                timer1.Enabled = false; // disable the timer while we work
                lastBufferPlotted = swhear.buffersRead;
                scottPlotUC1.plt.data.Clear();
                double[] signal = swhear.GetLinearPcmData();
                //signal = swhear.LowPassFilter(signal);
                scottPlotUC1.plt.data.AddSignal(signal, swhear.sampleRate);
                scottPlotUC1.Render();
                Application.DoEvents();
                timer1.Enabled = true; // re-enable the timer while we work
            }
        }
    }
}
