using Microsoft.AspNetCore.Mvc;
using TodoListApp.WebApp.Services;

namespace TodoListApp.WebApp.Controllers;
public class TodoListController : Controller
{
    private readonly ITodoListWebApiService todoListWebApiService;

    public TodoListController(ITodoListWebApiService todoListWebApiService)
    {
        this.todoListWebApiService = todoListWebApiService;
    }

    public async Task<IActionResult> Index()
    {
        var todolists = await this.todoListWebApiService.GetAllAsync();

        return this.View(todolists);
    }
}
