using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Assignment_4._2_Teacher_Student_Forms
{
    public partial class Teacher_Form : Form
    {
        public Teacher_Form()
        {
            InitializeComponent();
        }

        private void Teacher_Form_Load(object sender, EventArgs e)
        {
            studentGrid.DataSource = Data.Students;
            //Making sure the information fills up the grid to make it look nice
            studentGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Vertical
            studentGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Horizontal

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Addform addform = new Addform();
            addform.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete this student?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Student selectedStudent = (Student)studentGrid.CurrentRow.DataBoundItem;
                Data.Students.Remove(selectedStudent);
            }
        }


        private void btnSaveHighest_Click(object sender, EventArgs e)
        {
            if (Data.Students.Count == 0)
            {
                MessageBox.Show("No students available.");
                return;
            }

            var topStudent = Data.Students.OrderByDescending(s => s.GPA).FirstOrDefault();

            if (topStudent != null)
            {
                string path = "TopStudent.txt";
                string content =
                    $"Student ID: {topStudent.StudentId}\n" +
                    $"Name: {topStudent.StudentName}\n" +
                    $"GPA: {topStudent.GPA}";
            File.WriteAllText(path, content);
                MessageBox.Show($"Top student {topStudent.StudentName}'s info was saved to 'TopStudent.txt'");
            }

        }
    }
}
