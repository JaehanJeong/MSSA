using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Assignment_4._1
{
    public partial class Addform : Form
    {
        public Addform()
        {
            InitializeComponent();
        }

        private void Addform_Load(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Person newPerson = new Person()
            {
                FirstName = txtFName.Text,
                LastName = txtLName.Text,
                MobilePhone = txtMobPhone.Text,
                WorkPhone = txtWorkPhone.Text,
                Address = txtAddress.Text
            };
            string key = $"{newPerson.FirstName.Trim()} {newPerson.LastName.Trim()}";
            Data.PersonDict.Add(key, newPerson); // add to dictionary
            Data.Persons.Add(newPerson); // add to list
            MessageBox.Show("Contact added!");
            this.Close();
        }
    }
}
