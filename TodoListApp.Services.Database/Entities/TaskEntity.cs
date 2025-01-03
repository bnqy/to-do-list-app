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

    public DateTime? DueDate { get; set; }

    public bool IsCompleted { get; set; } = false;

    [ForeignKey(nameof(TodoListEntity))]
    public int TodoListId { get; set; }

    public TodoListEntity TodoList { get; set; }
}
