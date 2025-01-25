using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TodoListApp.WebApp.Models;

namespace TodoListApp.WebApp.Controllers;
public class HomeController : Controller
{
#pragma warning disable IDE0052 // Remove unread private members
#pragma warning disable S4487 // Unread "private" fields should be removed
#pragma warning disable SA1309 // Field names should not begin with underscore
    private readonly ILogger<HomeController> _logger;
#pragma warning restore SA1309 // Field names should not begin with underscore
#pragma warning restore S4487 // Unread "private" fields should be removed
#pragma warning restore IDE0052 // Remove unread private members

    public HomeController(ILogger<HomeController> logger)
    {
        this._logger = logger;
    }

#pragma warning disable CA5395
    public IActionResult Index()
    {
        return this.View();
    }

    public IActionResult Privacy()
    {
        return this.View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
    }
#pragma warning restore CA5395
}
