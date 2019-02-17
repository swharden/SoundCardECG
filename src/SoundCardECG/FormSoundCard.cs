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
    public partial class FormSoundCard : Form
    {
        public int deviceNumber; // access this variable from the parent form

        public FormSoundCard()
        {
            InitializeComponent();
        }

        private void FormSoundCard_Load(object sender, EventArgs e)
        {
            ScanSoundCards();
        }

        private void ScanSoundCards()
        {
            Log("Scanning sound cards...");

            listBox1.Items.Clear();
            btnSelect.Enabled = false;
            deviceNumber = -1;
            for (int i = 0; i < NAudio.Wave.WaveIn.DeviceCount; i++)
            {
                NAudio.Wave.WaveInCapabilities deviceInfo = NAudio.Wave.WaveIn.GetCapabilities(i);
                string name = deviceInfo.ProductName.Trim();
                if (name.Length == 31)
                    name += "...";
                listBox1.Items.Add($"Card {i + 1}: {name}");
            }

            if (listBox1.Items.Count > 0)
                Log($"Identified {listBox1.Items.Count} active microphones. Select the one you wish to monitor from the list.");
            else
                Log($"ERROR: no active microphones were found! Double-check your sound card settings and ensure a recording device is enabled.", true);
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            ScanSoundCards();
        }

        private void btnControlPanel_Click(object sender, EventArgs e)
        {
            var controlPanelPath = System.IO.Path.Combine(Environment.SystemDirectory, "control.exe");
            System.Diagnostics.Process.Start(controlPanelPath, "mmsys.cpl");
        }

        public void Log(string message, bool error = false)
        {
            tbMessage.Text = message;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSelect.Enabled = true;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            deviceNumber = listBox1.SelectedIndex;
            Close();
        }
    }
}
