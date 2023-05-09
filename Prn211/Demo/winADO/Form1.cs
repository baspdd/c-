using System.Data;
using System.Data.SqlClient;

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
                    "where account = @acc " +
                    "and password = @pass ";
                List<SqlParameter> param = new List<SqlParameter>
                {
                    new SqlParameter("@acc",txtAcc.Text),
                    new SqlParameter("@pass",txtPass.Text)
                };
                IDataReader dr = data.executeQuery2(strSelect,param.ToArray());
                DataTable ret = data.getUser(txtAcc.Text, txtPass.Text);
                if (dr.Read())
                {
                    frmCustomer f = new frmCustomer(txtAcc.Text);
                    f.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("login fail");
                }
                dr.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("login error :" + ex.Message);
            }
        }
        // Tạo đối tượng dataProvider
    }
}