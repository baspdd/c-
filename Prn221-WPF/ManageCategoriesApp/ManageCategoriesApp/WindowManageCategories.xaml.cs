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

        ManageCategories categories = new ManageCategories();
        private void Window_Loaded(object sender, RoutedEventArgs e) => LoadCategories();
        private void LoadCategories()
        {
            dgCategories.ItemsSource = categories.GetCategories();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            Category category = new Category(txtCategoryName.Text);
            categories.InsertCategory(category);

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dgCategories_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
