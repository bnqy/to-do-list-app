using Microsoft.EntityFrameworkCore;
using TodoListApp.Services.Database.Entities;

namespace TodoListApp.Services.Database.Contexts;
public class TodoListDbContext : DbContext
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public TodoListDbContext(DbContextOptions<TodoListDbContext> options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        : base(options)
    {
    }

    public DbSet<TodoListEntity> TodoLists { get; set; }

    public DbSet<TaskEntity> Tasks { get; set; }

    public DbSet<StatusEntity> Statuses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
#pragma warning disable IDE0058 // Expression value is never used
#pragma warning disable CA1062 // Validate arguments of public methods
        modelBuilder.Entity<StatusEntity>().HasData(
            new StatusEntity { Id = "completed", Name = "Completed" },
            new StatusEntity { Id = "in progress", Name = "In Progress" },
            new StatusEntity { Id = "not started", Name = "Not Started" });
#pragma warning restore CA1062 // Validate arguments of public methods
#pragma warning restore IDE0058 // Expression value is never used
    }
}
