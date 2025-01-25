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
#pragma warning disable CA1062 // Validate arguments of public methods
        var taskEntity = new TaskEntity
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            DueDate = task.DueDate,
            IsCompleted = task.IsCompleted,
            TodoListId = task.TodoListId,
            StatusId = "not started",
            AssignedToUserId = string.Empty,
        };
#pragma warning restore CA1062 // Validate arguments of public methods

        _ = this.todoListDbContext.Tasks.Add(taskEntity);

        _ = await this.todoListDbContext.SaveChangesAsync();
    }

    public async Task DeleteTaskAsync(int taskId)
    {
        var taskEntity = await this.todoListDbContext.Tasks.FindAsync(taskId);

        if (taskEntity is not null)
        {
            _ = this.todoListDbContext.Tasks.Remove(taskEntity);

            _ = await this.todoListDbContext.SaveChangesAsync();
        }
    }

#pragma warning disable CS8766 // Nullability of reference types in return type doesn't match implicitly implemented member (possibly because of nullability attributes).
    public async Task<TaskTodo>? GetTaskByIdAsync(int taskId)
#pragma warning restore CS8766 // Nullability of reference types in return type doesn't match implicitly implemented member (possibly because of nullability attributes).
    {
        var task = await this.todoListDbContext.Tasks.FindAsync(taskId);

#pragma warning disable CS8603 // Possible null reference return.
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
                StatusId = task.StatusId,
                AssignedToUserId = task.AssignedToUserId,
            };
#pragma warning restore CS8603 // Possible null reference return.
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
                StatusId = task.StatusId,
                AssignedToUserId = task.AssignedToUserId,
            })
            .ToListAsync();
    }

    public async Task UpdateTaskAsync(TaskTodo task)
    {
#pragma warning disable CA1062 // Validate arguments of public methods
        var taskEntity = await this.todoListDbContext.Tasks.FindAsync(task.Id);
#pragma warning restore CA1062 // Validate arguments of public methods

        if (taskEntity is not null)
        {
            taskEntity.Title = task.Title;
            taskEntity.Description = task.Description;
            taskEntity.IsCompleted = task.IsCompleted;
            taskEntity.DueDate = task.DueDate;

            _ = this.todoListDbContext.SaveChangesAsync();
        }
    }
}
