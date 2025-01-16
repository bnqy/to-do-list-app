using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListApp.Services.Database.Entities;
public class TaskEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Title { get; set; }

    [Required]
    [MaxLength(500)]
    public string? Description { get; set; }

    [Required]
    public DateTime? DueDate { get; set; }

    //public bool Completed => StatusId?.ToLower() == "Completed";

    public bool Completed { get; set; }

    public bool IsCompleted { get; set; }

    public bool Overdue { get; set; }
    //public bool Overdue => (StatusId?.ToLower() == "in progress" || StatusId?.ToLower() == "not started") && DueDate < DateTime.Today;

    [ForeignKey(nameof(TodoListEntity))]
    public int TodoListId { get; set; }

    [ForeignKey(nameof(StatusEntity))]
    public string StatusId { get; set; } = "Not Started";

    public string? AssignedToUserId { get; set; } = null!;

    public TodoListEntity TodoList { get; set; }

    public StatusEntity Status { get; set; }
}
