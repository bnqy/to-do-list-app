using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
