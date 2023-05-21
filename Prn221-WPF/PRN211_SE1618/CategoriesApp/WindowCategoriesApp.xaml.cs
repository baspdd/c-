using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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

namespace CategoriesApp
{
    /// <summary>
    /// Interaction logic for WindowCategoriesApp.xaml
    /// </summary>
    public partial class WindowCategoriesApp : Window
    {
        public WindowCategoriesApp()
        {
            InitializeComponent();
        }

        private void btnDisplay_Click(object sender, RoutedEventArgs e)
        {
            var str = txtCarName.Text + '\n' + txtColor.Text + '\n' + txtBrand.Text;
            MessageBox.Show(str, "Car Details");
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the new value of the slider
            double value = e.NewValue;

            // Perform actions based on the slider value
            // For example, update a label with the slider value
            txtBrand.Text = value.ToString();
        }
    }



}
