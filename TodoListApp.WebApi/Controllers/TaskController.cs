using Microsoft.AspNetCore.Mvc;
using TodoListApp.Services.Interfaces;
using TodoListApp.Services.Models;

namespace TodoListApp.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITaskDatabaseService taskDatabaseService;

    public TaskController(ITaskDatabaseService taskDatabaseService)
    {
        this.taskDatabaseService = taskDatabaseService;
    }

    [HttpGet("todolist/{todoListId}")]
    public async Task<IActionResult> GetTasksByTodoListId(int todoListId)
    {
        var tasks = await this.taskDatabaseService.GetTasksByTodoListIdAsync(todoListId);

        return this.Ok(tasks);
    }

    [HttpGet("{taskId}")]
    public async Task<IActionResult> GetTaskById(int taskId)
    {
        var task = await this.taskDatabaseService.GetTaskByIdAsync(taskId);

        return task == null ? this.NotFound() : this.Ok(task);
    }

    [HttpPost]
    public async Task<IActionResult> AddTask([FromBody] TaskTodo task)
    {
        /*if (!ModelState.IsValid)
        {
            return this.BadRequest(ModelState);
        }*/

        await this.taskDatabaseService.CreateTaskAsync(task);

        return this.CreatedAtAction(nameof(GetTaskById), new {taskId = task.Id}, task);
    }

    [HttpPut("{taskId}")]
    public async Task<IActionResult> UpdateTask(int taskId, [FromBody] TaskTodo task)
    {
        if (taskId != task.Id)
        {
            return this.BadRequest("Task Ids do not match.");
        }

        if (!ModelState.IsValid)
        {
            return this.BadRequest(ModelState);
        }

        await this.taskDatabaseService.UpdateTaskAsync(task);

        return this.NoContent();
    }

    [HttpDelete("{taskId}")]
    public async Task<IActionResult> DeleteTask(int taskId)
    {
        await this.taskDatabaseService.DeleteTaskAsync(taskId);

        return this.NoContent();
    }
}
