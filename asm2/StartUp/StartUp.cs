using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartUp
{
    public partial class StartUp : Form
    {
        public StartUp()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            //if (progressBar1.Value < 90)
            //{
            //    progressBar1.Value += 10;

            //}
            //else
            //{
            //    timer1.Enabled = false;
            //    frmMain f = new frmMain();
            //    f.Show();
            //    this.Hide();

            //}
            progressBar1.Increment(20);
            if (progressBar1.Value >= progressBar1.Maximum)
            {
                timer1.Enabled = false;
                frmMain f = new frmMain();
                this.Hide();
                f.Show();

            }
        }
    }
}
