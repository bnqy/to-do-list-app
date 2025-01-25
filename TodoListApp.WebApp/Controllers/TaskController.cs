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

#pragma warning disable S6967 // ModelState.IsValid should be called in controller actions
    public async Task<IActionResult> Index(int todoListId)
#pragma warning restore S6967 // ModelState.IsValid should be called in controller actions
    {
        var tasks = await this.taskWebApiService.GetTasksByTodoListIdAsync(todoListId);

        this.ViewBag.TodoListId = todoListId;

        return this.View(tasks);
    }

#pragma warning disable S6967 // ModelState.IsValid should be called in controller actions
    public async Task<IActionResult> Details(int id)
#pragma warning restore S6967 // ModelState.IsValid should be called in controller actions
    {
        var task = await this.taskWebApiService.GetTaskByIdAsync(id);

        return this.View(task);
    }

    // create
    [HttpGet]
#pragma warning disable S6967 // ModelState.IsValid should be called in controller actions
    public IActionResult Create(int todoListId)
#pragma warning restore S6967 // ModelState.IsValid should be called in controller actions
    {
        return this.View(new TaskTodo { TodoListId = todoListId });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TaskTodo task)
    {
        Console.WriteLine("ModelsTATES out if");
        if (this.ModelState.IsValid)
        {
            Console.WriteLine("ModelsTATES in if");

            await this.taskWebApiService.AddTaskAsync(task);

#pragma warning disable CA1062 // Validate arguments of public methods
            return this.RedirectToAction(nameof(this.Index), new { todoListId = task.TodoListId });
#pragma warning restore CA1062 // Validate arguments of public methods
        }

        Console.WriteLine("ModelsTATES out if 2");

        return this.View(task);
    }

    // Updt
    [HttpGet]
#pragma warning disable S4144 // Methods should not have identical implementations
#pragma warning disable S6967 // ModelState.IsValid should be called in controller actions
    public async Task<IActionResult> Edit(int id)
#pragma warning restore S6967 // ModelState.IsValid should be called in controller actions
#pragma warning restore S4144 // Methods should not have identical implementations
    {
        var task = await this.taskWebApiService.GetTaskByIdAsync(id);

        return this.View(task);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(TaskTodo task)
    {
        if (this.ModelState.IsValid)
        {
            await this.taskWebApiService.UpdateTaskAsync(task);

#pragma warning disable CA1062 // Validate arguments of public methods
            return this.RedirectToAction(nameof(this.Index), new { todoListId = task.TodoListId });
#pragma warning restore CA1062 // Validate arguments of public methods
        }

        return this.View(task);
    }

    // delete
    [HttpGet]
#pragma warning disable S4144 // Methods should not have identical implementations
#pragma warning disable S6967 // ModelState.IsValid should be called in controller actions
    public async Task<IActionResult> Delete(int id)
#pragma warning restore S6967 // ModelState.IsValid should be called in controller actions
#pragma warning restore S4144 // Methods should not have identical implementations
    {
        var task = await this.taskWebApiService.GetTaskByIdAsync(id);

        return this.View(task);
    }

    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
#pragma warning disable S6967 // ModelState.IsValid should be called in controller actions
    public async Task<IActionResult> DeleteConfirmed(int id, int todoListId)
#pragma warning restore S6967 // ModelState.IsValid should be called in controller actions
    {
        await this.taskWebApiService.DeleteTaskAsync(id);

        return this.RedirectToAction(nameof(this.Index), new { todoListId });
    }
}
