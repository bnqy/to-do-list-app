using Microsoft.AspNetCore.Mvc;
using TodoListApp.Services.Interfaces;
using TodoListApp.Services.Models;

namespace TodoListApp.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoListController : ControllerBase
{
    private readonly ITodoListDatabaseService todoListDatabaseService;

    public TodoListController(ITodoListDatabaseService todoListDatabaseService)
    {
        this.todoListDatabaseService = todoListDatabaseService;
    }

    // Get `1`: api/TodoList
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoList>>> GetTotoLists()
    {
        var todolists = await this.todoListDatabaseService.GetAllAsync();

        return this.Ok(todolists);
    }

    // Get `2`: api/todolist/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<TodoList>> GetTodoList(int id)
    {
        var todolist = await this.todoListDatabaseService.GetByIdAsync(id);

        if (todolist is null)
        {
            return this.NotFound();
        }

        return this.Ok(todolist);
    }

    // Post `3`: api/todolist
    [HttpPost]
    public async Task<ActionResult> CreateTodoList([FromBody] TodoList todoList)
    {
        await this.todoListDatabaseService.AddAsync(todoList);

        return this.CreatedAtAction(nameof(this.GetTodoList), new {id = todoList.Id}, todoList);
    }

    // Put `4`: api/todolist/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateTodoList(int id, [FromBody] TodoList todoList)
    {
        if (id != todoList.Id)
        {
            return this.BadRequest("Ids are not match!");
        }

        await this.todoListDatabaseService.UpdateAsync(todoList);

        return this.NoContent();
    }

    // Delete `5`: api/TodoList/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTodoList(int id)
    {
        await this.todoListDatabaseService.DeleteAsync(id);

        return this.NoContent();
    }
}
