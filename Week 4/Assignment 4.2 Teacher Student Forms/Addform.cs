using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Assignment_4._2_Teacher_Student_Forms
{
    public partial class Addform : Form
    {
        public Addform()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Student student = new Student()
            {
                StudentId = int.Parse(txtStudentID.Text),
                StudentName = txtStudentName.Text,
                GPA = float.Parse(txtGPA.Text)
            };
            Data.Students.Add(student);
            MessageBox.Show("Student added!");
            this.Close();
        }
    }
}
