using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Assignment_3._4
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Get Data from Coffe list
            coffeeGrid.DataSource = Data.Coffees;

            //Making sure the information fills up the grid to make it look nice
            coffeeGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Vertical
            coffeeGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Horizontal
            
            // Had to manually set it all because I wanted beverage size to be second column but that forces everything to be set manually
            coffeeGrid.Columns["CoffeeName"].DisplayIndex = 0;
            coffeeGrid.Columns["BeverageSize"].DisplayIndex = 1;
            coffeeGrid.Columns["Shots"].DisplayIndex = 2;
            coffeeGrid.Columns["Bean"].DisplayIndex = 3;
            coffeeGrid.Columns["Milk"].DisplayIndex = 4;
            coffeeGrid.Columns["Price"].DisplayIndex = 5;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {   //Button to add coffee to orders
            Addform addform = new Addform();
            addform.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {   //Button to delete coffee
            
            //Warning message
            var result = MessageBox.Show("Are you sure you want to delete?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) //If they pick yes
            {   
                Data.Coffees.RemoveAt(coffeeGrid.CurrentRow.Index); // Delete the selected row
                coffeeGrid.DataSource = null;
                coffeeGrid.DataSource = Data.Coffees; // Update the list
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {   //Update list, but... thanks to BindingList, I don't think we need a refresh button anymore.
            coffeeGrid.DataSource = null;
            coffeeGrid.DataSource = Data.Coffees;
        }
    }
}
