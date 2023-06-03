using BusinessObject.Models;
using DataAcess.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly IProductRepository _productRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IOrderRepository _orderRepository;

        public Login(IProductRepository productRepository, IMemberRepository memberRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _memberRepository = memberRepository;
            _orderRepository = orderRepository;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var email = txtEmail.Text;
            var pass = txtPassword.Password;

            var conf = new ConfigurationBuilder().AddJsonFile("appsettings.json")
                 .Build().GetSection("Admin");

            if (String.IsNullOrEmpty(email) || String.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Please enter");
            }


            if (email.Equals(conf["email"]) && pass.Equals(conf["pass"]))
            {
                //this.Hide();
                ProductManagement productManagement = new ProductManagement(_productRepository, _memberRepository, _orderRepository);
                productManagement.Show();
                this.Close();
            }
            else { MessageBox.Show("wrong sth please enter again"); }
        }
    }
}
