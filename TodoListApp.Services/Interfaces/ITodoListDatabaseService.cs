using TodoListApp.Services.Models;

namespace TodoListApp.Services.Interfaces;
public interface ITodoListDatabaseService
{
    Task<List<TodoList>> GetAllAsync();

    Task<TodoList> GetByIdAsync(int id);

    Task AddAsync(TodoList todoList);

    Task DeleteAsync(int id);

    Task UpdateAsync(TodoList todoList);
}
