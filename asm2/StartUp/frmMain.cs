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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"..\\..\\..\\pic\\in.png");
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            pictureBox1.Image = Image.FromFile(@"..\\..\\..\\pic\\lyon.png");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"..\\..\\..\\pic\\fullham.png");
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
          
            pictureBox1.Image = Image.FromFile(@"..\\..\\..\\pic\\arsenal.png");
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"..\\..\\..\\pic\\tot.png");
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"..\\..\\..\\pic\\mu.png");
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"..\\..\\..\\pic\\ale.png");
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"..\\..\\..\\pic\\real.png");

        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"..\\..\\..\\pic\\ba.png");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"..\\..\\..\\pic\\lyon.png");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Lunar f = new Lunar();
            this.Hide();
            f.Show();
        }
    }
}
