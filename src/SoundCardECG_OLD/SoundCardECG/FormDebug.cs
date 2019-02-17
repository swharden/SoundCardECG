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
    public partial class FormDebug : Form
    {
        SWHear swhear;
        public FormDebug(SWHear swhear)
        {
            InitializeComponent();
            this.swhear = swhear;
        }

        private void FormDebug_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = swhear.GetStats();
        }
    }
}
