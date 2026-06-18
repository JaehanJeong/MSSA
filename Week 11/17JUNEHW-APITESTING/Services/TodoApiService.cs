using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TodoClient.Models;

namespace TodoClient.Services
{
    public class TodoApiService
    {
        private readonly HttpClient _httpClient;

        public TodoApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7238/")
            };
        }

        // READ all
        public async Task<List<TodoItem>> GetTodosAsync()
        {
            var todos = await _httpClient.GetFromJsonAsync<List<TodoItem>>("api/TodoItems");
            return todos ?? new List<TodoItem>();
        }

        // CREATE
        public async Task<TodoItem?> CreateTodoAsync(TodoItem newTodo)
        {
            var response = await _httpClient.PostAsJsonAsync("api/TodoItems", newTodo);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<TodoItem>();
        }

        // UPDATE
        public async Task UpdateTodoAsync(TodoItem todo)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/TodoItems/{todo.Id}", todo);
            response.EnsureSuccessStatusCode();
        }

        // DELETE
        public async Task DeleteTodoAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/TodoItems/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}