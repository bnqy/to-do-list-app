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
    public async Task<IActionResult> Delete(int id)
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
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await this.todoListWebApiService.DeleteAsync(id);

        return this.RedirectToAction(nameof(this.Index));
    }
}
