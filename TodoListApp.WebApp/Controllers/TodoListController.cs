using Microsoft.AspNetCore.Mvc;
using TodoListApp.Services.Models;
using TodoListApp.WebApp.Services;

namespace TodoListApp.WebApp.Controllers;
public class TodoListController : Controller
{
    private readonly ITodoListWebApiService todoListWebApiService;

    public TodoListController(ITodoListWebApiService todoListWebApiService)
    {
        this.todoListWebApiService = todoListWebApiService;
    }

    // Get: /TodoList
    public async Task<IActionResult> Index()
    {
        var todolists = await this.todoListWebApiService.GetAllAsync();

        return this.View(todolists);
    }

    // Get: /TodoList/Create
    public IActionResult Create()
    {
        return this.View();
    }

    // Post: /TodoList/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TodoList todoList)
    {
        if (this.ModelState.IsValid)
        {
            await this.todoListWebApiService.CreateAsync(todoList);

            return this.RedirectToAction(nameof(this.Index));
        }

        return this.View(todoList);
    }

    // Get: /TodoList/Delete/{id}
    [HttpGet]
#pragma warning disable S6967 // ModelState.IsValid should be called in controller actions
    public async Task<IActionResult> Delete(int id)
#pragma warning restore S6967 // ModelState.IsValid should be called in controller actions
    {
        var todolist = await this.todoListWebApiService.GetByIdAsync(id);

        if (todolist is null)
        {
            return this.NotFound();
        }

        return this.View(todolist);
    }

    // Post: /TodoList/Delete/{id}
    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
#pragma warning disable S6967 // ModelState.IsValid should be called in controller actions
    public async Task<IActionResult> DeleteConfirmed(int id)
#pragma warning restore S6967 // ModelState.IsValid should be called in controller actions
    {
        await this.todoListWebApiService.DeleteAsync(id);

        return this.RedirectToAction(nameof(this.Index));
    }

    // Get: /Todolist/Edit/{id}
    [HttpGet]
#pragma warning disable S4144 // Methods should not have identical implementations
#pragma warning disable S6967 // ModelState.IsValid should be called in controller actions
    public async Task<IActionResult> Edit(int id)
#pragma warning restore S6967 // ModelState.IsValid should be called in controller actions
#pragma warning restore S4144 // Methods should not have identical implementations
    {
        var todolist = await this.todoListWebApiService.GetByIdAsync(id);

        if (todolist is null)
        {
            return this.NotFound();
        }

        return this.View(todolist);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(TodoList todolist)
    {
        if (!this.ModelState.IsValid)
        {
            return this.View(todolist);
        }

        await this.todoListWebApiService.UpdateAsync(todolist);
        return this.RedirectToAction(nameof(this.Index));
    }
}
