using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartUp
{
    public partial class Lunar : Form
    {
        public Lunar()
        {
            InitializeComponent();
        }

        private void Lunar_Load(object sender, EventArgs e)
        {
            button1.Image = Image.FromFile(@"..\\..\\..\\pic\\exit.png");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMain f = new frmMain();
            this.Hide();
            this.Close();
            f.Show();
        }

        private void textBox1_CursorChanged(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Pink;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Regex.Match(textBox1.Text, "[0-9]+").Success)
            {
                int year = Int32.Parse(textBox1.Text);
                string luna = getLunar(year);
                textBox2.Text = luna;
            }
            else
            {
                textBox2.Text = "";
            }
        }

        private string getLunar(int year)
        {
            string ret = "";
            year -= 3;
            int cal = year % 10;
            int cal2 = year % 12;
            switch (cal)
            {
                case 0: ret = "Quý"; break;
                case 1: ret = "Giáp"; break;
                case 2: ret = "Ất"; break;
                case 3: ret = "Bính"; break;
                case 4: ret = "Đính"; break;
                case 5: ret = "Mậu"; break;
                case 6: ret = "Kỷ"; break;
                case 7: ret = "Canh"; break;
                case 8: ret = "Tân"; break;
                case 9: ret = "Nhâm"; break;
                default:
                    break;
            }
            switch (cal2)
            {
                case 0: ret += " " + "Hợi"; break;
                case 1: ret += " " + "Tý"; break;
                case 2: ret += " " + "Sửu"; break;
                case 3: ret += " " + "Dần"; break;
                case 4: ret += " " + "Mão"; break;
                case 5: ret += " " + "Thìn"; break;
                case 6: ret += " " + "Tị"; break;
                case 7: ret += " " + "Ngọ"; break;
                case 8: ret += " " + "Mùi"; break;
                case 9: ret += " " + "Thân"; break;
                case 10: ret += " " + "Dậu"; break;
                case 11: ret += " " + "Tuất"; break;

                default:
                    break;
            }
            return ret;
        }

        private void textBox2_MouseHover(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.Pink;
        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Pink;
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
        }

        private void textBox2_MouseLeave(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.White;
        }
    }
}
