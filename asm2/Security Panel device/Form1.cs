namespace Security_Panel_device
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        String txt = "";
        private void button1_Click(object sender, EventArgs e)
        {
            txt += "1";
            txtSecurityCode.Text = txt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txt += "2";
            txtSecurityCode.Text = txt;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            txt += "3";
            txtSecurityCode.Text = txt;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            txt += "4";
            txtSecurityCode.Text = txt;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            txt += "5";
            txtSecurityCode.Text = txt;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            txt += "6";
            txtSecurityCode.Text = txt;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            txt += "7";
            txtSecurityCode.Text = txt;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            txt += "8";
            txtSecurityCode.Text = txt;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            txt += "9";
            txtSecurityCode.Text = txt;

        }

        private void button0_Click(object sender, EventArgs e)
        {
            txt += "0";
            txtSecurityCode.Text = txt;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txt = "";
            txtSecurityCode.Text = txt;

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int val = Convert.ToInt32(txt);
            String att = "";
            if (val == 1645 || val == 1689) att = "Technicians";
            else if (val == 8345) att = "Custodians";
            else if (val == 9998 || val == 1006 || val == 1008) att = "Sciencetist";
            else att = "Restricted Access!";
            lbxAccessLog.Items.Add(DateTime.Now + "\t" + att);
        }
    }
}