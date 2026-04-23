using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Assignment_3._4
{
    public partial class Addform : Form
    {
        public Addform()
        {
            InitializeComponent();
        }

        private void Addform_Load(object sender, EventArgs e)
        {

            //Get the values for these enums
            comboSize.DataSource = Enum.GetValues(typeof(beverageSize));
            comboCoffeeName.DataSource = Enum.GetValues(typeof(CoffeeName));
            comboMilk.DataSource = Enum.GetValues(typeof(MilkType));
            comboBean.DataSource = Enum.GetValues(typeof(BeanType));


            //These variables contribute to updated prices.
            comboSize.SelectedIndexChanged += (s, e) => UpdatePrice();
            comboMilk.SelectedIndexChanged += (s, e) => UpdatePrice();
            comboBean.SelectedIndexChanged += (s, e) => UpdatePrice();
            numShots.ValueChanged += (s, e) => UpdatePrice();

            UpdatePrice(); // Calculate the price right at the end
        }

        private void UpdatePrice()
        {
            Coffee preview = new Coffee()
            {
                //Grab appropriate values
                BeverageSize = (beverageSize)comboSize.SelectedItem,
                Milk = (MilkType)comboMilk.SelectedItem,
                Bean = (BeanType)comboBean.SelectedItem,
                Shots = (int)numShots.Value
            };
            //Price displayed will change for this instance's getprice calculation, with F2 formatting (for money)
            lblPriceDisplay.Text = $"Price: ${preview.GetPrice():F2}";
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            Coffee newCoffee = new Coffee()
            {

                //Simple adding of the coffee based on our user input.
                CoffeeName = (CoffeeName)comboCoffeeName.SelectedItem,
                Milk = (MilkType)comboMilk.SelectedItem,
                Bean = (BeanType)comboBean.SelectedItem,
                BeverageSize = (beverageSize)comboSize.SelectedItem,
                Shots = (int)numShots.Value  // assuming a NumericUpDown for shots
            };
            Data.Coffees.Add(newCoffee);
            MessageBox.Show("Coffee added!");
            this.Close();//Quite a nice update to make it clean. Closes the window 
        }
    }
}
