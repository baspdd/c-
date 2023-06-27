using BusinessObject.Models;
using DataAcess.Repository;
using SaleWPFApp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF
{
    /// <summary>
    /// Interaction logic for ProductManagement.xaml
    /// </summary>
    public partial class ProductManagement : Window
    {
        private readonly IProductRepository _productRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IOrderRepository _orderRepository;

        public ProductManagement(IProductRepository productRepository, IMemberRepository memberRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _memberRepository = memberRepository;
            _orderRepository = orderRepository;
            InitializeComponent();
            LoadProductList();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadProductList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void LoadProductList()
        {
            lvProducts.ItemsSource = _productRepository.getAllProducts();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = getProductInfo();
                _productRepository.addProduct(product);
                LoadProductList();
                MessageBox.Show($"Add {product.ProductName} successfully");
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding product: " + ex.Message);
            }
        }

        private Product getProductInfo()
        {
            Product product = null;
            try
            {
                product = new Product
                {
                    ProductId = String.IsNullOrEmpty(txtProductId.Text) ? 0 : int.Parse(txtProductId.Text),
                    ProductName = txtProductName.Text,
                    CategoryId = int.Parse(txtCategoryId.Text),
                    Weight = txtWeight.Text,
                    UnitPrice = Convert.ToDecimal(txtUnitPrice.Text),
                    UnitsInStock = Convert.ToInt32(txtQuantity.Text)
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting product: " + ex.Message);
            }
            return product;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = getProductInfo();
                _productRepository.updateProduct(product);
                LoadProductList();
                MessageBox.Show("Edit product successfully");
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating product: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = getProductInfo();
                _productRepository.deleteProduct(product);
                LoadProductList();
                MessageBox.Show($"Delete {product.ProductName} successfully");
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting product" + ex.Message);
            }
        }

        private void btnSearchById_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string productId = txtProductId.Text;
                if (productId == null)
                {
                    MessageBox.Show("Please fill in the product ID");
                }
                else
                {
                    List<Product> product = new List<Product>();
                    product.Add(_productRepository.getProductById(int.Parse(productId)));
                    lvProducts.ItemsSource = product;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnSearchByPrice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string price = txtUnitPrice.Text;
                if (price == null)
                {
                    MessageBox.Show("Please fill in the product price");
                }
                else
                {
                    lvProducts.ItemsSource = _productRepository.getProductsByPrice(decimal.Parse(price)); ;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnSearchByQuantity_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string quantity = txtQuantity.Text;
                if (quantity == null)
                {
                    MessageBox.Show("Please fill in the product price");
                }
                else
                {
                    lvProducts.ItemsSource = _productRepository.getProductsByQuantity(int.Parse(quantity));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login(_productRepository, _memberRepository, _orderRepository);
            login.Show();
            this.Close();
        }

        private void btnLoadOrders_Click(object sender, RoutedEventArgs e)
        {
            OrderManagement orderManagement = new OrderManagement(_productRepository, _memberRepository, _orderRepository);
            orderManagement.Show();
            this.Close();
        }

        private void btnLoadMembers_Click(object sender, RoutedEventArgs e)
        {
            MemberManagement member = new MemberManagement(_productRepository, _memberRepository, _orderRepository);
            member.Show();
            this.Close();
        }

        public void lv_click(object sender, RoutedEventArgs e)
        {
            //var item = (sender as ListView).SelectedItem;
            //if (item != null)
            //{
            //    var product = (Product)item;
            //    if (product.CategoryId == 1)
            //    {
            //        checkBox.IsChecked = true;
            //    }
            //    else checkBox.IsChecked = false;
            //}
        }

        public bool IsCategoryActive
        {
            get { return checkBox.IsChecked.GetValueOrDefault(); }
            set
            {
                var item = (Product)lvProducts.SelectedItem;
                if (item.CategoryId == 1)
                {
                    checkBox.IsChecked = true;
                }
                else checkBox.IsChecked = false;
            }
        }



    }
}
