using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            //pictureBox1.Image = Image.FromFile(@"..\\..\\..\\pic\\lyon.png");
            Image img = Image.FromFile(@"..\\..\\..\\pic\\lyon.png");
            Bitmap b = new Bitmap(img);
            Image i = resizeImage(b, new Size(100, 100));
            pictureBox1.Image = i;
        }

        private static System.Drawing.Image resizeImage(System.Drawing.Image imgToResize, Size size)
        {
            //Get the image current width  
            int sourceWidth = imgToResize.Width;
            //Get the image current height  
            int sourceHeight = imgToResize.Height;
            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            //Calulate  width with new desired size  
            nPercentW = ((float)size.Width / (float)sourceWidth);
            //Calculate height with new desired size  
            nPercentH = ((float)size.Height / (float)sourceHeight);
            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;
            //New Width  
            int destWidth = (int)(sourceWidth * nPercent);
            //New Height  
            int destHeight = (int)(sourceHeight * nPercent);
            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((System.Drawing.Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            // Draw image with new width and height  
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return (System.Drawing.Image)b;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Lunar f = new Lunar();
            this.Hide();
            f.Show();
        }
    }
}
