using ASM1;
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
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            String email = txtEmail.Text;
            String pass = txtPassword.Password;

            var conf = new ConfigurationBuilder().AddJsonFile("appsettings.json")
                .Build().GetSection("Admin");

            if (String.IsNullOrEmpty(email) || String.IsNullOrEmpty(pass))
            {
                MessageBox.Show("input");
            }


            if (email.Equals(conf["email"]) && pass.Equals(conf["pass"]))
            {
                Product product = new Product();
                product.Show();
                this.Close();
                //this.Hide();
            }

        }
    }
}
