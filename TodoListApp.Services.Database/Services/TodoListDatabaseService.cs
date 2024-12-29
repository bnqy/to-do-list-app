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
public class TodoListDatabaseService : ITodoListDatabaseService
{
    private readonly TodoListDbContext todoListDbContext;

    public TodoListDatabaseService(TodoListDbContext todoListDbContext)
    {
        this.todoListDbContext = todoListDbContext;
    }

    public async Task AddAsync(TodoList todoList)
    {
        var entity = new TodoListEntity
        {
            Name = todoList.Name,
            Description = todoList.Description,
            CreatedAt = DateTime.UtcNow,
        };

        this.todoListDbContext.TodoLists.Add(entity);

        await this.todoListDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await this.todoListDbContext.TodoLists.FindAsync(id);
        if (entity == null)
        {
            return;
        }

        this.todoListDbContext.TodoLists.Remove(entity);
        await this.todoListDbContext.SaveChangesAsync();
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
            return null;
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
        var entity = await this.todoListDbContext.TodoLists.FindAsync(todoList.Id);
        if (entity == null)
        {
            return;
        }

        entity.Name = todoList.Name;
        entity.Description = todoList.Description;
        entity.UpdatedAt = DateTime.UtcNow;

        await this.todoListDbContext.SaveChangesAsync();
    }
}
