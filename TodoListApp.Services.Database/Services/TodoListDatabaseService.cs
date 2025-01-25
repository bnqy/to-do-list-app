using Microsoft.EntityFrameworkCore;
using TodoListApp.Services.Database.Contexts;
using TodoListApp.Services.Database.Entities;
using TodoListApp.Services.Interfaces;
using TodoListApp.Services.Models;

namespace TodoListApp.Services.Database.Services;
public class TodoListDatabaseService : ITodoListDatabaseService
{
    private readonly TodoListDbContext todoListDbContext;

    public TodoListDatabaseService(TodoListDbContext todoListDbContext)
    {
        this.todoListDbContext = todoListDbContext;
    }

    public async Task AddAsync(TodoList todoList)
    {
#pragma warning disable CA1062 // Validate arguments of public methods
        var entity = new TodoListEntity
        {
            Name = todoList.Name,
            Description = todoList.Description,
            CreatedAt = DateTime.UtcNow,
        };
#pragma warning restore CA1062 // Validate arguments of public methods

        _ = this.todoListDbContext.TodoLists.Add(entity);

        _ = await this.todoListDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await this.todoListDbContext.TodoLists.FindAsync(id);
        if (entity == null)
        {
            return;
        }

        _ = this.todoListDbContext.TodoLists.Remove(entity);
        _ = await this.todoListDbContext.SaveChangesAsync();
    }

    public async Task<List<TodoList>> GetAllAsync()
    {
        return await this.todoListDbContext.TodoLists
            .Select(entity => new TodoList
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
            })
            .ToListAsync();
    }

    public async Task<TodoList> GetByIdAsync(int id)
    {
        var entity = await this.todoListDbContext.TodoLists.FindAsync(id);
        if (entity == null)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return null;
#pragma warning restore CS8603 // Possible null reference return.
        }

        return new TodoList
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
        };
    }

    public async Task UpdateAsync(TodoList todoList)
    {
#pragma warning disable CA1062 // Validate arguments of public methods
        var entity = await this.todoListDbContext.TodoLists.FindAsync(todoList.Id);
#pragma warning restore CA1062 // Validate arguments of public methods
        if (entity == null)
        {
            return;
        }

        entity.Name = todoList.Name;
        entity.Description = todoList.Description;
        entity.UpdatedAt = DateTime.UtcNow;

        _ = await this.todoListDbContext.SaveChangesAsync();
    }
}
