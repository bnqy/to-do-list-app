using System.ComponentModel.DataAnnotations;

namespace TodoListApp.Services.Database.Entities;
public class TodoListEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public string Name { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    [MaxLength(500)]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public string Description { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

#pragma warning disable CA2227 // Collection properties should be read only
    public ICollection<TaskEntity> Tasks { get; set; } = new List<TaskEntity>();
#pragma warning restore CA2227 // Collection properties should be read only
}
