using winform_EF.Models;

namespace winform_EF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MySaleDBContext context = new MySaleDBContext();
        private void Form1_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            try
            {
                var data = context.Products
                    .Select(item => new
                    {
                        ProductId = item.ProductId,
                        ProductName = item.ProductName,
                        UnitPrice = item.UnitPrice,
                        UnitInStock = item.UnitsInStock,
                        CategoryName = item.Category.CategoryName,
                        Image = item.Image
                    }).ToList();
                dgPro.DataSource = data;
                cbProductID.DataSource = data;
                cbProductID.DisplayMember = "ProductId";
                cbProductID.ValueMember = "ProductId";

                var data2 = context.Categories.ToList();
                cbCategory.DataSource = data;
                cbCategory.DisplayMember = "CategoryName";
                cbCategory.ValueMember = "CategoryName";

                //Biding dữ liệu lên form
                cbProductID.DataBindings.Clear();
                cbProductID.DataBindings.Add("Text", data, "ProductId");

                txtProName.DataBindings.Clear();
                txtProName.DataBindings.Add("Text", data, "ProductName");

                txtPrice.DataBindings.Clear();
                txtPrice.DataBindings.Add("Text", data, "UnitPrice");

                txtInstock.DataBindings.Clear();
                txtInstock.DataBindings.Add("Text", data, "UnitInStock");

                cbCategory.DataBindings.Clear();
                cbCategory.DataBindings.Add("Text", data, "CategoryName");

                txtImage.DataBindings.Clear();
                txtImage.DataBindings.Add("Text", data, "Image");
            }
            catch (Exception ex)
            {

                MessageBox.Show("load " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDel_Click(object sender, EventArgs e)
        {

        }
    }
}