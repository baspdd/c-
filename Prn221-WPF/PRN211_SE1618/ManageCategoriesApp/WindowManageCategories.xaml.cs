using System.Collections.Generic;
using System.Windows;

namespace ManageCategoriesApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dgCategories_Loaded(object sender, RoutedEventArgs e)
        {
            List<dynamic> categories = new List<dynamic>
            {
                new {CategoryID = "1", CategoryName = "ABC"},
                new {CategoryID = "2", CategoryName = "DEF"},
            };
            dgCategories.ItemsSource = categories;
        }
    }
}
