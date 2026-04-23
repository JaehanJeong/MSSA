using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Assignment_3._3_Student_Management
{
    public partial class Addform : Form
    {
        public Addform()
        {
            InitializeComponent();
        }

        private void txtStudId_Validating(object sender, CancelEventArgs e)
        {
            if (txtStudId.TextLength != 0)
            {
                int val;
                if (!int.TryParse(txtStudId.Text, out val))
                {
                    MessageBox.Show("Please enter numbers only.");
                    e.Cancel = true;
                    txtStudId.Clear();
                }
                else if (int.Parse(txtStudId.Text) <= 0)
                {
                    MessageBox.Show("Enter non negative numbers.");
                    e.Cancel = true;
                    txtStudId.Clear();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text != string.Empty && txtLastName.Text != string.Empty)
            {
                Student newstudent = new Student();
                newstudent.studid = int.Parse(txtStudId.Text);
                newstudent.firstName = txtFirstName.Text;
                newstudent.lastName = txtLastName.Text;
                newstudent.address = txtAddress.Text;
                newstudent.monthOfAdmission = (Month)(comboMonth.SelectedIndex+1);
                char c;
                if (char.TryParse(txtGrade.Text, out c))
                {
                    newstudent.grade = c;
                }
                else
                {
                    MessageBox.Show("Enter a single character only.");
                }
                Data.Students.Add(newstudent);
                MessageBox.Show("Student added!");
            }
        }

        private void Addform_Load(object sender, EventArgs e)
        {
            comboMonth.DataSource = Enum.GetValues(typeof(Month));
        }
    }
}
