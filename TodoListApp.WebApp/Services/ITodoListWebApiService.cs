using TodoListApp.Services.Models;

namespace TodoListApp.WebApp.Services;

public interface ITodoListWebApiService
{
    Task<IEnumerable<TodoList>> GetAllAsync();

    Task<TodoList> GetByIdAsync(int id);

    Task CreateAsync(TodoList todoList);

    Task UpdateAsync(TodoList todoList);

    Task DeleteAsync(int id);
}
