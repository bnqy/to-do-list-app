using TodoListApp.Services.Models;

namespace TodoListApp.WebApp.Services;

public interface ITaskWebApiService
{
    Task<IEnumerable<TaskTodo>> GetTasksByTodoListIdAsync(int todoListId);

    Task<TaskTodo> GetTaskByIdAsync(int taskId);

    Task AddTaskAsync(TaskTodo task);

    Task UpdateTaskAsync(TaskTodo task);

    Task DeleteTaskAsync(int taskId);
}
