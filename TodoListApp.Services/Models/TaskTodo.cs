using System.ComponentModel.DataAnnotations;

namespace TodoListApp.Services.Models;
public class TaskTodo
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required.")]
    [MaxLength(200)]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public string Title { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    [MaxLength(500, ErrorMessage = "Max length of Description is 500.")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Enter due date.")]
    public DateTime? DueDate { get; set; } = DateTime.MaxValue;

#pragma warning disable CA1805 // Do not initialize unnecessarily
    public bool IsCompleted { get; set; } = false;
#pragma warning restore CA1805 // Do not initialize unnecessarily

    public string StatusId { get; set; } = "Not Started";

#pragma warning disable CA1304 // Specify CultureInfo
#pragma warning disable CA1311 // Specify a culture or use an invariant version
    public bool Completed => this.StatusId?.ToLower() == "completed" || this.IsCompleted;
#pragma warning restore CA1311 // Specify a culture or use an invariant version
#pragma warning restore CA1304 // Specify CultureInfo

    [Required(ErrorMessage = "TodoList id is required.")]
    public int TodoListId { get; set; }

#pragma warning disable CA1304 // Specify CultureInfo
#pragma warning disable CA1311 // Specify a culture or use an invariant version
    public bool Overdue => (this.StatusId?.ToLower() == "in progress" || this.StatusId?.ToLower() == "not started") && this.DueDate < DateTime.Today;
#pragma warning restore CA1311 // Specify a culture or use an invariant version
#pragma warning restore CA1304 // Specify CultureInfo

    public string? AssignedToUserId { get; set; } = string.Empty;
}
