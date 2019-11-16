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
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
        }

        private void FormAbout_Load(object sender, EventArgs e)
        {
            Version ver = typeof(FormAbout).Assembly.GetName().Version;
            lblVersion.Text = $"version {ver}";
        }

        private void label6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/swharden/SoundCardECG");
        }

        private void label4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.swharden.com/wp/about-scott/");
        }

        private void label7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.swharden.com/wp/about-scott/");
        }

        private void label8_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.swharden.com/wp/about-scott/");
        }
    }
}
