using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mod3EmpSystem
{
    public partial class Addform : Form
    {
        public Addform()
        {
            InitializeComponent();
        }

        private void txtEmpId_Validating(object sender, CancelEventArgs e)
        {// Whatever user enters should be numbers!
            if (txtEmpId.TextLength != 0) // Data is entered, so we'll do the check
            {
                int val; // out variable that's needed
                if (!int.TryParse(txtEmpId.Text, out val)) // If invalid
                {
                    //We'll throw a message box
                    MessageBox.Show("Please enter numbers only.");
                    e.Cancel = true; // Keep the focus on the same text box 
                    //because we have not enetered a valid data.
                    txtEmpId.Clear();
                }
                else if (int.Parse(txtEmpId.Text) <= 0)
                {
                    MessageBox.Show("Enter non negative numbers.");
                    e.Cancel = true; // Important to cancel otherwise no point in doing this - cursor focus stays there
                    txtEmpId.Clear();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text != string.Empty)
                //if (txtName.Text != string.Empty && txtFirstName.text != string.Empty)
            {// Need it for all the properties 
                Employee newemp = new Employee();
                newemp.EmployeeID = int.Parse(txtEmpId.Text);
                newemp.Name = txtName.Text;
                newemp.salaray = double.Parse(txtSalaray.Text);
                newemp.Department = (Department)(comboDept.SelectedIndex + 1); // Type casting allows the value thats integer is saved as number
                Data.Employees.Add(newemp);
                MessageBox.Show("Record added");
            }
        }

        private void Addform_Load(object sender, EventArgs e)
        {
            comboDept.DataSource = Enum.GetValues(typeof(Department));
        }
    }
}
