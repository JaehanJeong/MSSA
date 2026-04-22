using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mod3EmpSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            empGrid.DataSource = Data.Employees;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Data.Employees.RemoveAt(empGrid.CurrentRow.Index);
                empGrid.DataSource = null; // precaution to ensure that it's not holding any data
                empGrid.DataSource = Data.Employees; // New data just to refresh
            }
            else
            {

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

            empGrid.DataSource = null; // precaution to ensure that it's not holding any data
            empGrid.DataSource = Data.Employees; // New data just to refresh
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Addform addform = new Addform();
            addform.ShowDialog();
        }
    }
}
