using System;
using System.Linq;
using System.Windows;
using TodoClient.Models;
using TodoClient.Services;

namespace TodoClient
{
    public partial class MainWindow : Window
    {
        private readonly TodoApiService _apiService = new TodoApiService();
        private TodoItem? _selectedTodo;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += async (s, e) => await LoadTodosAsync();
        }

        private async System.Threading.Tasks.Task LoadTodosAsync()
        {
            var todos = await _apiService.GetTodosAsync();
            TodoListBox.ItemsSource = todos;
        }

        private void TodoListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            _selectedTodo = TodoListBox.SelectedItem as TodoItem;
            if (_selectedTodo != null)
            {
                TitleTextBox.Text = _selectedTodo.Title;
                IsCompleteCheckBox.IsChecked = _selectedTodo.IsComplete;
            }
        }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var newTodo = new TodoItem
            {
                Title = TitleTextBox.Text,
                IsComplete = IsCompleteCheckBox.IsChecked ?? false
            };

            await _apiService.CreateTodoAsync(newTodo);
            await LoadTodosAsync();

            TitleTextBox.Clear();
            IsCompleteCheckBox.IsChecked = false;
        }

        private async void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedTodo == null)
            {
                MessageBox.Show("Select a todo first.");
                return;
            }

            _selectedTodo.Title = TitleTextBox.Text;
            _selectedTodo.IsComplete = IsCompleteCheckBox.IsChecked ?? false;

            await _apiService.UpdateTodoAsync(_selectedTodo);
            await LoadTodosAsync();
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedTodo == null)
            {
                MessageBox.Show("Select a todo first.");
                return;
            }

            await _apiService.DeleteTodoAsync(_selectedTodo.Id);
            await LoadTodosAsync();

            TitleTextBox.Clear();
            IsCompleteCheckBox.IsChecked = false;
            _selectedTodo = null;
        }
    }
}