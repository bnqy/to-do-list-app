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
        _ = await this.httpClient.PostAsJsonAsync("api/TodoList", todoList);
    }

    public async Task DeleteAsync(int id)
    {
#pragma warning disable CA2234 // Pass system uri objects instead of strings
        _ = await this.httpClient.DeleteAsync($"api/TodoList/{id}");
#pragma warning restore CA2234 // Pass system uri objects instead of strings
    }

    public async Task<IEnumerable<TodoList>> GetAllAsync()
    {
#pragma warning disable CS8603 // Possible null reference return.
        return await this.httpClient.GetFromJsonAsync<IEnumerable<TodoList>>("api/TodoList");
#pragma warning restore CS8603 // Possible null reference return.
    }

    public async Task<TodoList> GetByIdAsync(int id)
#pragma warning disable S125 // Sections of code should not be commented out
    {
#pragma warning disable CS8603 // Possible null reference return.
        return await this.httpClient.GetFromJsonAsync<TodoList>($"api/TodoList/{id}");
#pragma warning restore CS8603 // Possible null reference return.

        /*var response = await this.httpClient.GetAsync($"api/TodoList/{id}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TodoList>();*/
    }
#pragma warning restore S125 // Sections of code should not be commented out

    public async Task UpdateAsync(TodoList todoList)
    {
#pragma warning disable CA1062 // Validate arguments of public methods
        _ = await this.httpClient.PutAsJsonAsync($"api/TodoList/{todoList.Id}", todoList);
#pragma warning restore CA1062 // Validate arguments of public methods
    }
}
