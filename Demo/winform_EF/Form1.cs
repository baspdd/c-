using System.Xml.Linq;
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
                        UnitsInStock = item.UnitsInStock,
                        CategoryName = item.Category.CategoryName,
                        Image = item.Image
                    })
                    .ToList();

                dgPro.DataSource = data;

                cbProductID.DataSource = data;
                cbProductID.DisplayMember = "ProductId";
                cbProductID.ValueMember = "ProductId";

                var data2 = context.Categories.ToList();
                cbCategory.DataSource = data2;
                cbCategory.DisplayMember = "CategoryName";
                cbCategory.ValueMember = "CategoryId";

                //Binding dữ liệu lên form
                cbProductID.DataBindings.Clear();
                cbProductID.DataBindings.Add("Text", data, "ProductId");

                txtProName.DataBindings.Clear();
                txtProName.DataBindings.Add("Text", data, "ProductName");

                txtPrice.DataBindings.Clear();
                txtPrice.DataBindings.Add("Text", data, "UnitPrice");

                txtInstock.DataBindings.Clear();
                txtInstock.DataBindings.Add("Text", data, "UnitsInstock");

                txtImage.DataBindings.Clear();
                txtImage.DataBindings.Add("Text", data, "Image");

                cbCategory.DataBindings.Clear();
                cbCategory.DataBindings.Add("Text", data, "CategoryName");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load error:" + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Product product = new Product
                {
                    ProductName = txtProName.Text,
                    UnitPrice = decimal.Parse(txtPrice.Text),
                    UnitsInStock = Int32.Parse(txtInstock.Text),
                    Image = txtImage.Text,
                    CategoryId = (int)cbCategory.SelectedValue
                };
                // Add vào DB
                context.Products.Add(product);
                if (context.SaveChanges() > 0)
                {
                    loadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("add " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //Tìm đối tượng cần update
                Product p = context.Products.FirstOrDefault(item => item.ProductId == Int32.Parse(cbProductID.Text));
                if (p != null)
                {
                    p.ProductName = txtProName.Text;
                    p.UnitPrice = decimal.Parse(txtPrice.Text);
                    p.UnitsInStock = Int32.Parse(txtInstock.Text);
                    p.Image = txtImage.Text;
                    p.CategoryId = (int)cbCategory.SelectedValue;

                    if (context.SaveChanges() > 0)
                    {
                        loadData();
                    }
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("update error:" + ex.Message);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                //Tìm đối tượng cần update
                Product p = context.Products.FirstOrDefault(item => item.ProductId == Int32.Parse(cbProductID.Text));
                if (p != null)
                {
                    context.Products.Remove(p);
                    if (context.SaveChanges() > 0)
                    {
                        loadData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete error:" + ex.Message);
            }
        }

        private void dgPro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgPro.Columns[e.ColumnIndex].Name == "Delete")
            {
                try
                {
                    //Tìm đối tượng cần update
                    string code = dgPro.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                    Product p = context.Products.FirstOrDefault(item => item.ProductId == Int32.Parse(code));
                    if (p != null)
                    {
                        context.Products.Remove(p);
                        if (context.SaveChanges() > 0)
                        {
                            loadData();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Delete error:" + ex.Message);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var data = context.Products
                    .Select(item => new
                    {
                        ProductId = item.ProductId,
                        ProductName = item.ProductName,
                        UnitPrice = item.UnitPrice,
                        UnitsInStock = item.UnitsInStock,
                        CategoryName = item.Category.CategoryName,
                        Image = item.Image
                    }).Where(item => item.ProductName.Contains(txtProName.Text))
                    .ToList();

            dgPro.DataSource = data;
    }
    }
}