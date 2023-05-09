using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winADO
{
    public partial class FrmProduct : Form
    {
        public FrmProduct()
        {
            InitializeComponent();
        }

        DataProvider data = new DataProvider();
        private void FrmProduct_Load(object sender, EventArgs e)
        {
            dgCustomer.DataSource = data.executeQuery("SELECT [ProductID]\r\n      ,[ProductName]\r\n      ,[UnitPrice]\r\n      ,[UnitsInStock]\r\n      ,[Image]\r\n      ,[CategoryName]\r\n      ,[Discontinued]\r\n  FROM [Products] p \r\n  JOIN [Categories] c on p.[CategoryID] = c.[CategoryID]");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
            //Application.Exit();
        }

        private void dgCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string img = dgCustomer.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
            WebRequest request = WebRequest.Create(img);
            using (var response = request.GetResponse())
            {
                using (var str = response.GetResponseStream())
                {
                    pic.Image = Bitmap.FromStream(str);
                }
            }
        }
    }
}
