using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListApp.Services.Models;
public class TaskTodo
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required.")]
    [MaxLength(200)]
    public string Title { get; set; }

    [MaxLength(500, ErrorMessage = "Max length of Description is 500.")]
    public string? Description { get; set; }

    public DateTime? DueDate { get; set; }

    public bool IsCompleted { get; set; } = false;

    [Required(ErrorMessage = "TodoList id is required.")]
    public int TodoListId { get; set; }
}
