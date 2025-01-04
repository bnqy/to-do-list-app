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

    public string Title { get; set; }

    public string? Description { get; set; }

    public DateTime? DueDate { get; set; }

    public bool IsCompleted { get; set; } = false;

    public int TodoListId { get; set; }
}
