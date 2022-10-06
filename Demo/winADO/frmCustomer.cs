using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winADO
{
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
        }

        public frmCustomer(string text)
        {
            InitializeComponent();
            Text = "helo" + text;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            FrmProduct f = new FrmProduct();
            f.Show();
            this.Hide();
            
        }
        DataProvider data = new DataProvider();
        private void loadData()
        {
            dgCustomer.DataSource = data.executeQuery("select * from Customers");
            cbCusID.DataSource = data.executeQuery("select * from Customers");
            cbCusID.DisplayMember = "CustomerId";
            cbCusID.ValueMember = "CustomerId";
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                bool gender = true;
                if (rdFemale.Checked) gender = false;
                String strInsert = "insert into Customers" +
                    "(CustomerName,Birthdate,Gender,Address)" +
                    "values(N'" + txtCusName.Text + "'," +
                    "'" + txtDOB.Text + "'," +
                    "'" + gender + "'," +
                    "N'" + txtAddress.Text + "') ";
                if (data.executeNonQuery(strInsert))
                {
                    MessageBox.Show("add succcess");
                    loadData();
                }

            }
            catch (Exception exx)
            {

                MessageBox.Show("add errror : " + exx.Message);
            }
        }

        private void dgCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbCusID.Text = dgCustomer.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
            txtCusName.Text = dgCustomer.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
            txtDOB.Text = dgCustomer.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
            if (dgCustomer.Rows[e.RowIndex].Cells[3].FormattedValue.ToString().Equals("True"))
                rdMale.Checked = true;
            else rdFemale.Checked = true;
            txtAddress.Text = dgCustomer.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                bool gender = true;
                if (rdFemale.Checked) gender = false;
                String strUp = "UPDATE [Customers]" +
                    "   SET [CustomerName] = N'" + txtCusName.Text + "'" +
                    "   ,[Birthdate] = '" + txtDOB.Text + "' " +
                    "   ,[Gender] = '" + gender + "' " +
                    "   ,[Address] = N'"+txtAddress.Text+"' " +
                    "   WHERE [CustomerId] = '" + cbCusID.Text + "'";

                if (data.executeNonQuery(strUp))
                {
                    MessageBox.Show("up succcess");
                    loadData();
                }

            }
            catch (Exception exx)
            {

                MessageBox.Show("add errror : " + exx.Message);
            }
        }
    }
}
