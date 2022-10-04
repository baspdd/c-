using System.Data;

namespace winADO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataProvider data = new DataProvider();

        private void btnLog_Click(object sender, EventArgs e)
        {
            try
            {
                String strSelect = "select * from Users " +
                    "where account = '"+ txtAcc.Text+"'" +
                    "and password = '"+txtPass.Text+"'";
                DataTable dt = data.executeQuery(strSelect);
                DataTable ret = data.getUser(txtAcc.Text,txtPass.Text);
                if (ret.Rows.Count>0)
                {
                    frmCustomer f = new frmCustomer(txtAcc.Text);
                    f.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("login fail");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("login error :" + ex.Message);
            }
        }
        // Tạo đối tượng dataProvider
    }
}