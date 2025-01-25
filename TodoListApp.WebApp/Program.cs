using TodoListApp.WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient<ITodoListWebApiService, TodoListWebApiService>(
    client =>
    {
#pragma warning disable S1075 // URIs should not be hardcoded
        client.BaseAddress = new Uri("https://localhost:7123/");
#pragma warning restore S1075 // URIs should not be hardcoded
    });

builder.Services.AddHttpClient<ITaskWebApiService, TaskWebApiService>(
    client =>
    {
#pragma warning disable S1075 // URIs should not be hardcoded
        client.BaseAddress = new Uri("https://localhost:7123/");
#pragma warning restore S1075 // URIs should not be hardcoded
    });

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
#pragma warning disable IDE0058 // Expression value is never used
    app.UseExceptionHandler("/Home/Error");
#pragma warning restore IDE0058 // Expression value is never used

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
#pragma warning disable IDE0058 // Expression value is never used
    app.UseHsts();
#pragma warning restore IDE0058 // Expression value is never used
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

#pragma warning disable S6966 // Awaitable method should be used
app.Run();
#pragma warning restore S6966 // Awaitable method should be used
