using BusinessObject.Models;
using DataAccess.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
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

namespace SaleWPFApp
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
            // lấy email, pass nhập từ user
            String email = txtEmail.Text;
            String password = txtPassword.Password;
            
            
            // lấy thoong tin tài khoản từ file appsetting
        
            var account = new ConfigurationBuilder().AddJsonFile("appsettings.json")
                .Build().GetSection("account");

            // kiểm tra email, pass có trùng vs account k
            if (email != null && password != null)
            {
                // admin access
                if (email.Equals(account["email"]) && password.Equals(account["password"]))
                {
                    //MessageBox.Show("Dang nhap thanh cong");
                    Hide();
                    ProductManagement productManagement = new ProductManagement(_productRepository, _memberRepository, _orderRepository);
                    productManagement.Show();

                }
                // normal access
                else
                {
                    MessageBox.Show("Dang nhap that bai");
                    //Member member = _memberRepository.getMemberByEmail(email, password);
                    //if (member != null)
                    //{
                    //    Hide();
                    //    ProfileManagement profileManagement = new ProfileManagement(_productRepository, _memberRepository, _orderRepository, email, password);
                    //    profileManagement.Show();
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Email or password is incorrect");
                    //}
                }
            }
            else
            {
                MessageBox.Show("Please enter email and password");
            }
        }
    }
}
