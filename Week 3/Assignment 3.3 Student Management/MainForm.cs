using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Assignment_3._3_Student_Management
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            studentGrid.DataSource = Data.Students;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Data.Students.RemoveAt(studentGrid.CurrentRow.Index);
                studentGrid.DataSource = null; // Precaution to ensure that it's not holding any data?
                studentGrid.DataSource = Data.Students; // New data just to refresh
            }
            else
            {
                // Let's see what sensei put
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            studentGrid.DataSource = null;
            studentGrid.DataSource = Data.Students;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Addform addform = new Addform();
            addform.ShowDialog();
        }
    }
}
