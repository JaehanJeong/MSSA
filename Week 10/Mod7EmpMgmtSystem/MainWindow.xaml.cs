using Mod7EmpMgmtSystem.Models;
using Mod7EmpMgmtSystem.Services;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mod7EmpMgmtSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CRUD crud = new CRUD();
        private Employee selectedEmployee;
        private void LoadEmployees()
        {
            dgEmployees.ItemsSource = null;
            dgEmployees.ItemsSource = crud.GetAllEmployees();
        }

        private void LoadDepartments()
        {
            cmbDepartment.ItemsSource = crud.GetAllDepartments();
            cmbDepartment.DisplayMemberPath = "DeptName";
            cmbDepartment.SelectedValuePath = "DeptId";
        }

        private void Clear()
        {
            txtEmployeeId.IsEnabled = true;
            txtEmployeeId.Clear();
            txtEmployeeName.Clear();
            txtEmployeeSalary.Clear();
            cmbDepartment.SelectedIndex = -1;
            dgEmployees.SelectedItem = null;
            selectedEmployee = null;
        }
        public MainWindow()
        {
            InitializeComponent();
            LoadEmployees();
            LoadDepartments();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Employee newemp = new Employee
            {
                EmpId = int.Parse(txtEmployeeId.Text),
                EmpName = txtEmployeeName.Text,
                Salary = double.Parse(txtEmployeeSalary.Text),
                DeptId = (int)cmbDepartment.SelectedValue

            };
            crud.AddEmployee(newemp);
            LoadEmployees();
            Clear();
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if(selectedEmployee == null)
            {
                MessageBox.Show("Select employee first..");
                return;
            }
            Employee emp = new Employee
            {
                EmpName = txtEmployeeName.Text,
                Salary = double.Parse(txtEmployeeSalary.Text),
                DeptId = (int)cmbDepartment.SelectedValue

            };
            crud.UpdateEmployee(selectedEmployee.EmpId, emp);
            LoadEmployees();
            Clear();

        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(selectedEmployee == null)
            {
                MessageBox.Show("Please select an employee to delete..");
                return;
            }

            MessageBoxResult result =
                MessageBox.Show(
                    $"Delete employee {selectedEmployee.EmpName}?",
                    "Confirm delete",
                    MessageBoxButton.YesNo
                    
                    );
            if (result == MessageBoxResult.Yes)
            {
                crud.DeleteEmployee(selectedEmployee.EmpId);
                LoadEmployees();
                Clear();
            }

        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }
        private void dgEmp_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedEmployee = dgEmployees.SelectedItem as Employee;
            if (selectedEmployee == null)
                return;
            txtEmployeeId.Text=selectedEmployee.EmpId.ToString();
            txtEmployeeName.Text = selectedEmployee.EmpName;
            txtEmployeeSalary.Text = selectedEmployee.Salary.ToString();
            cmbDepartment.SelectedValue = selectedEmployee.DeptId;
            txtEmployeeId.IsEnabled = false;
        }

    }
}