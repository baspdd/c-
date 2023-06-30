using Q1.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Q1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly PRN221_Spr22Context context;
        public MainWindow(PRN221_Spr22Context context)
        {
            InitializeComponent();
            this.context = context;
            HandleBeforeLoad();
        }

        public void UpdateGridView()
        {
            listEmployee.ItemsSource = context.Employees.ToList();
        }

        private void HandleBeforeLoad()
        {
            UpdateGridView();
        }

        public Employee GetEmployeeObject()
        {
            try
            {
                return new Employee
                {
                    Id = string.IsNullOrEmpty(employeeId.Text) ? 0 : int.Parse(employeeId.Text),
                    Name = employeeName.Text,
                    Gender = male.IsChecked == true ? "Male" : "Female",
                    Phone = phone.Text,
                    Dob = dob.SelectedDate,
                    Idnumber = idNumber.Text
                };
            }
            catch (System.Exception)
            {
                MessageBox.Show("Can't get employee", "Get Employee");
            }
            return null;
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            employeeId.Text = string.Empty;
            employeeName.Text = string.Empty;
            male.IsChecked = true;
            phone.Text = string.Empty;
            dob.SelectedDate = null;
            idNumber.Text = string.Empty;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var employee = GetEmployeeObject();
                if (employee != null)
                {
                    employee.Id = 0;
                    context.Employees.Add(employee);
                    context.SaveChanges();
                    UpdateGridView();
                    MessageBox.Show("Insert Employee Succeed", "Add employee");
                }
            }
            catch (System.Exception)
            {
                MessageBox.Show("Insert Employee Failed", "Add employee");
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var employee = GetEmployeeObject();
                if (employee != null)
                {
                    var oldEmployee = context.Employees.FirstOrDefault(e => e.Id == employee.Id);
                    if (oldEmployee != null)
                    {
                        oldEmployee.Name = employee.Name;
                        oldEmployee.Gender = employee.Gender;
                        oldEmployee.Phone = employee.Phone;
                        oldEmployee.Dob = employee.Dob;
                        oldEmployee.Idnumber = employee.Idnumber;
                        context.Employees.Update(oldEmployee);
                        context.SaveChanges();
                        UpdateGridView();
                        MessageBox.Show("Update Employee Succeed", "Update employee");
                    }
                }
            }
            catch (System.Exception)
            {
                MessageBox.Show("Update Employee Failed", "Update employee");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var employee = GetEmployeeObject();
                if (employee != null)
                {
                    var oldEmployee = context.Employees.FirstOrDefault(e => e.Id == employee.Id);
                    if (oldEmployee != null)
                    {
                        context.Employees.Remove(oldEmployee);
                        context.SaveChanges();
                        UpdateGridView();
                        MessageBox.Show("Delete Employee Succeed", "Delete employee");
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete employee");
            }
        }

        private void listView_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            if (item != null)
            {
                var gender = ((Employee)item).Gender;
                if (!string.IsNullOrEmpty(gender))
                {
                    if (gender.ToLower() == "female")
                    {
                        female.IsChecked = true;
                    }
                    else
                    {
                        male.IsChecked = true;
                    }
                }
            }
        }
    }
}
