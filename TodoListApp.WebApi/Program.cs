using Microsoft.EntityFrameworkCore;
using TodoListApp.Services.Database.Contexts;
using TodoListApp.Services.Database.Services;
using TodoListApp.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ITodoListDatabaseService, TodoListDatabaseService>();
builder.Services.AddScoped<ITaskDatabaseService, TaskDatabaseService>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TodoListDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("TodoListDb")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
#pragma warning disable IDE0058 // Expression value is never used
    app.UseSwagger();
#pragma warning restore IDE0058 // Expression value is never used
#pragma warning disable IDE0058 // Expression value is never used
    app.UseSwaggerUI();
#pragma warning restore IDE0058 // Expression value is never used
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

#pragma warning disable S6966 // Awaitable method should be used
app.Run();
#pragma warning restore S6966 // Awaitable method should be used
