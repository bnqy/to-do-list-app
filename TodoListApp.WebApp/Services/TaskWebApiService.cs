using TodoListApp.Services.Models;

namespace TodoListApp.WebApp.Services;

public class TaskWebApiService : ITaskWebApiService
{
    private readonly HttpClient httpClient;

    public TaskWebApiService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task AddTaskAsync(TaskTodo task)
    {
        _ = await this.httpClient.PostAsJsonAsync("api/task", task);
    }

    public async Task DeleteTaskAsync(int taskId)
    {
#pragma warning disable CA2234 // Pass system uri objects instead of strings
        _ = await this.httpClient.DeleteAsync($"api/task/{taskId}");
#pragma warning restore CA2234 // Pass system uri objects instead of strings
    }

    public async Task<TaskTodo> GetTaskByIdAsync(int taskId)
    {
#pragma warning disable CS8603 // Possible null reference return.
        return await this.httpClient.GetFromJsonAsync<TaskTodo>($"api/task/{taskId}");
#pragma warning restore CS8603 // Possible null reference return.
    }

    public async Task<IEnumerable<TaskTodo>> GetTasksByTodoListIdAsync(int todoListId)
    {
#pragma warning disable CS8603 // Possible null reference return.
        return await this.httpClient.GetFromJsonAsync<IEnumerable<TaskTodo>>($"api/task/todolist/{todoListId}");
#pragma warning restore CS8603 // Possible null reference return.
    }

    public async Task UpdateTaskAsync(TaskTodo task)
    {
#pragma warning disable CA1062 // Validate arguments of public methods
        _ = await this.httpClient.PutAsJsonAsync($"api/task/{task.Id}", task);
#pragma warning restore CA1062 // Validate arguments of public methods
    }
}
