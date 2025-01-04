using Microsoft.AspNetCore.Mvc;
using TodoListApp.Services.Models;
using TodoListApp.WebApp.Services;

namespace TodoListApp.WebApp.Controllers;
public class TaskController : Controller
{
    private readonly ITaskWebApiService taskWebApiService;

    public TaskController(ITaskWebApiService taskWebApiService)
    {
        this.taskWebApiService = taskWebApiService;
    }

    public async Task<IActionResult> Index(int todoListId)
    {
        var tasks = await this.taskWebApiService.GetTasksByTodoListIdAsync(todoListId);

        ViewBag.TodoListId = todoListId;

        return this.View(tasks);
    }

    public async Task<IActionResult> Details(int id)
    {
        var task = await this.taskWebApiService.GetTaskByIdAsync(id);

        return this.View(task);
    }


    // create
    [HttpGet]
    public IActionResult Create(int todoListId)
    {
        return this.View(new TaskTodo { TodoListId = todoListId });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TaskTodo task)
    {
        if (ModelState.IsValid)
        {
            await this.taskWebApiService.AddTaskAsync(task);

            return this.RedirectToAction(nameof(this.Index), new {todoListId = task.TodoListId});
        }

        return this.View(task);
    }


    // Updt
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var task = await this.taskWebApiService.GetTaskByIdAsync(id);

        return this.View(task);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(TaskTodo task)
    {
        if (ModelState.IsValid)
        {
            await this.taskWebApiService.UpdateTaskAsync(task);

            return this.RedirectToAction(nameof(this.Index), new {todoListId = task.TodoListId});
        }

        return this.View(task);
    }

    // delete
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var task = await this.taskWebApiService.GetTaskByIdAsync(id);

        return this.View(task);
    }

    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id, int todoListId)
    {
        await this.taskWebApiService.DeleteTaskAsync(id);

        return this.RedirectToAction(nameof(this.Index), new {todoListId});
    }
}
