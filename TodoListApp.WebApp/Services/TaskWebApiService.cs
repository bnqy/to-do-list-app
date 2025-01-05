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
        await this.httpClient.PostAsJsonAsync("api/task", task);
    }

    public async Task DeleteTaskAsync(int taskId)
    {
        await this.httpClient.DeleteAsync($"api/task/{taskId}");
    }

    public async Task<TaskTodo> GetTaskByIdAsync(int taskId)
    {
        return await this.httpClient.GetFromJsonAsync<TaskTodo>($"api/task/{taskId}");
    }

    public async Task<IEnumerable<TaskTodo>> GetTasksByTodoListIdAsync(int todoListId)
    {
        return await this.httpClient.GetFromJsonAsync<IEnumerable<TaskTodo>>($"api/task/todolist/{todoListId}");
    }

    public async Task UpdateTaskAsync(TaskTodo task)
    {
        await this.httpClient.PutAsJsonAsync($"api/task/{task.Id}", task);
    }
}
