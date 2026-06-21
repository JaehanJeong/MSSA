using Assignment_10._3.Models;
using Assignment_10._3.Services;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Assignment_10._3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CRUD crud = new CRUD();

        public MainWindow()
        {
            InitializeComponent();
            LoadCars();
        }

        private void LoadCars()
        {
            dgCars.ItemsSource = crud.GetAllCars();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var car = new Car
                {
                    VIN = txtVIN.Text.Trim(),
                    Make = txtMake.Text.Trim(),
                    Model = txtModel.Text.Trim(),
                    Year = int.Parse(txtYear.Text.Trim()),
                    Price = double.Parse(txtPrice.Text.Trim())
                };

                crud.AddCar(car);
                LoadCars();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter valid car details.\n" + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtVIN.Text))
            {
                MessageBox.Show("Select a car from the grid first.");
                return;
            }

            try
            {
                var car = new Car
                {
                    VIN = txtVIN.Text.Trim(),
                    Make = txtMake.Text.Trim(),
                    Model = txtModel.Text.Trim(),
                    Year = int.Parse(txtYear.Text.Trim()),
                    Price = double.Parse(txtPrice.Text.Trim())
                };

                crud.UpdateCar(car);
                LoadCars();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter valid car details.\n" + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtVIN.Text))
            {
                MessageBox.Show("Select a car from the grid first.");
                return;
            }

            crud.DeleteCar(txtVIN.Text.Trim());
            LoadCars();
            ClearFields();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtVIN.Text = "";
            txtMake.Text = "";
            txtModel.Text = "";
            txtYear.Text = "";
            txtPrice.Text = "";
            dgCars.SelectedItem = null;
        }

        private void dgCars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgCars.SelectedItem is Car selected)
            {
                txtVIN.Text = selected.VIN;
                txtMake.Text = selected.Make;
                txtModel.Text = selected.Model;
                txtYear.Text = selected.Year.ToString();
                txtPrice.Text = selected.Price.ToString();
            }
        }
    }
}