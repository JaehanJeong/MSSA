using Assignment_11._1.Models;
using Assignment_11._1.Services;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Assignment_11._1
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
            LoadBooks();
        }

        private void LoadBooks()
        {
            dgBooks.ItemsSource = crud.GetAllBooks();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var book = new Book
                {
                    ISBN = txtISBN.Text.Trim(),
                    Title = txtTitle.Text.Trim(),
                    AuthorName = txtAuthor.Text.Trim(),
                    Description = txtDescription.Text.Trim()
                };

                crud.AddBook(book);
                LoadBooks();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter valid book details.\n" + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtISBN.Text))
            {
                MessageBox.Show("Select a book from the grid first.");
                return;
            }

            try
            {
                var book = new Book
                {
                    ISBN = txtISBN.Text.Trim(),
                    Title = txtTitle.Text.Trim(),
                    AuthorName = txtAuthor.Text.Trim(),
                    Description = txtDescription.Text.Trim()
                };

                crud.UpdateBook(book);
                LoadBooks();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter valid book details.\n" + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtISBN.Text))
            {
                MessageBox.Show("Select a book from the grid first.");
                return;
            }

            crud.DeleteBook(txtISBN.Text.Trim());
            LoadBooks();
            ClearFields();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtISBN.Text = "";
            txtTitle.Text = "";
            txtAuthor.Text = "";
            txtDescription.Text = "";
            dgBooks.SelectedItem = null;
        }

        private void dgBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgBooks.SelectedItem is Book selected)
            {
                txtISBN.Text = selected.ISBN;
                txtTitle.Text = selected.Title;
                txtAuthor.Text = selected.AuthorName;
                txtDescription.Text = selected.Description;
            }
        }
    }
}