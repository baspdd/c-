using System;
using System.Windows;
using System.Windows.Interop;

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

        ManageCategories categories = new ManageCategories();
        private void Window_Loaded(object sender, RoutedEventArgs e) => LoadCategories();
        private void LoadCategories()
        {
            dgCategories.ItemsSource = categories.GetCategories();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var category = new Category(txtCategoryName.Text);
                categories.InsertCategory(category);
                LoadCategories();
            }
            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message, "Insert");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var category = new Category(Int32.Parse(txtCategoryID.Text), txtCategoryName.Text);
                categories.UpdateCategory(category);
                LoadCategories();
            }
            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message, "Uodate");
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var category = new Category { CategoryID = Int32.Parse(txtCategoryID.Text) };
                categories.DeleteCategory(category);
                LoadCategories();
            }
            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message, "Uodate");
            }
        }

        private void dgCategories_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
