using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoListApp.Services.Database.Entities;
public class TaskEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public string Title { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    [Required]
    [MaxLength(500)]
    public string? Description { get; set; }

    [Required]
    public DateTime? DueDate { get; set; }

    public bool Completed { get; set; }

    public bool IsCompleted { get; set; }

    public bool Overdue { get; set; }

    [ForeignKey(nameof(TodoListEntity))]
    public int TodoListId { get; set; }

    [ForeignKey(nameof(StatusEntity))]
    public string StatusId { get; set; } = "Not Started";

    public string? AssignedToUserId { get; set; } = null!;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public TodoListEntity TodoList { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public StatusEntity Status { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
