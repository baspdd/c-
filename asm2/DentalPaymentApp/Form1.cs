using System.Text.RegularExpressions;

namespace DentalPaymentApp
{
    public partial class Dental : Form
    {
        public Dental()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GetPay(object sender, EventArgs e)
        {
            String  name = txtName.Text;
            if (String.IsNullOrEmpty(name)  || !Regex.Match(name,"[a-zA-Z ]+").Success)
            {
                MessageBox.Show(this, "You must input your name to continue !", "Alert");
                return;
            }
            int total = 0;
            if (chkClean.Checked) total += 100;
            if (chkWhitenning.Checked) total += 1200;
            if (chkXRay.Checked) total += 200;
            total += 80 * (int)NumericUpDown.Value;
            txtTotal.Text = (total > 0 ) ? total.ToString() + ".000" : total.ToString();
        }
    }
}