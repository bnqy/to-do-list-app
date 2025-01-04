using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListApp.Services.Models;

namespace TodoListApp.Services.Interfaces;
public interface ITaskDatabaseService
{
    Task<IEnumerable<TaskTodo>> GetTasksByTodoListIdAsync(int todoListId);

    Task<TaskTodo> GetTaskByIdAsync(int taskId);

    Task CreateTaskAsync(TaskTodo task);

    Task UpdateTaskAsync(TaskTodo task);

    Task DeleteTaskAsync(int taskId);
}
