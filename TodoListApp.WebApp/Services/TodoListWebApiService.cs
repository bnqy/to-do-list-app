using TodoListApp.Services.Models;

namespace TodoListApp.WebApp.Services;

public class TodoListWebApiService : ITodoListWebApiService
{
    private readonly HttpClient httpClient;

    public TodoListWebApiService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task CreateAsync(TodoList todoList)
    {
        await this.httpClient.PostAsJsonAsync("api/TodoList", todoList);
    }

    public async Task DeleteAsync(int id)
    {
        await this.httpClient.DeleteAsync($"api/TodoList/{id}");
    }

    public async Task<IEnumerable<TodoList>> GetAllAsync()
    {
        return await this.httpClient.GetFromJsonAsync<IEnumerable<TodoList>>("api/TodoList");
    }

    public async Task<TodoList> GetByIdAsync(int id)
    {
        return await this.httpClient.GetFromJsonAsync<TodoList>($"api/TodoList/{id}");
    }

    public async Task UpdateAsync(TodoList todoList)
    {
        await this.httpClient.PutAsJsonAsync($"api/TodoList/{todoList.Id}", todoList);
    }
}
