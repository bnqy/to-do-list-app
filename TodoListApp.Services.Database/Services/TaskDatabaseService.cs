using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoListApp.Services.Database.Contexts;
using TodoListApp.Services.Database.Entities;
using TodoListApp.Services.Interfaces;
using TodoListApp.Services.Models;

namespace TodoListApp.Services.Database.Services;
public class TaskDatabaseService : ITaskDatabaseService
{
    private readonly TodoListDbContext todoListDbContext;

    public TaskDatabaseService(TodoListDbContext todoListDbContext)
    {
        this.todoListDbContext = todoListDbContext;
    }

    public async Task CreateTaskAsync(TaskTodo task)
    {
        var taskEntity = new TaskEntity
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            DueDate = task.DueDate,
            IsCompleted = task.IsCompleted,
            TodoListId = task.TodoListId,
        };

        this.todoListDbContext.Tasks.Add(taskEntity);

        await this.todoListDbContext.SaveChangesAsync();
    }

    public async Task DeleteTaskAsync(int taskId)
    {
        var taskEntity = await this.todoListDbContext.Tasks.FindAsync(taskId);

        if (taskEntity is not null)
        {
            this.todoListDbContext.Tasks.Remove(taskEntity);

            await this.todoListDbContext.SaveChangesAsync();
        }
    }

    public async Task<TaskTodo>? GetTaskByIdAsync(int taskId)
    {
        var task = await this.todoListDbContext.Tasks.FindAsync(taskId);

        return task == null
            ? null
            : new TaskTodo
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                IsCompleted = task.IsCompleted,
                TodoListId = task.TodoListId,
            };
    }

    public async Task<IEnumerable<TaskTodo>> GetTasksByTodoListIdAsync(int todoListId)
    {
        return await this.todoListDbContext.Tasks
            .Where(tid => tid.TodoListId == todoListId)
            .Select(task => new TaskTodo
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                IsCompleted = task.IsCompleted,
                DueDate = task.DueDate,
                TodoListId = task.TodoListId,
            })
            .ToListAsync();
    }

    public async Task UpdateTaskAsync(TaskTodo task)
    {
        var taskEntity = await this.todoListDbContext.Tasks.FindAsync(task.Id);

        if (taskEntity is not null)
        {
            taskEntity.Title = task.Title;
            taskEntity.Description = task.Description;
            taskEntity.IsCompleted = task.IsCompleted;
            taskEntity.DueDate = task.DueDate;

            this.todoListDbContext.SaveChangesAsync();
        }
    }
}
