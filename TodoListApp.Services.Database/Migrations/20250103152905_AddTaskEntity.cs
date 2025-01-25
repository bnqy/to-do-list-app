#pragma warning disable IDE0005 // Using directive is unnecessary.
using System;
#pragma warning restore IDE0005 // Using directive is unnecessary.
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoListApp.Services.Database.Migrations
{
    public partial class AddTaskEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
#pragma warning disable IDE0058 // Expression value is never used
#pragma warning disable CA1062 // Validate arguments of public methods
#pragma warning disable SA1413 // Use trailing comma in multi-line initializers
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    TodoListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_TodoLists_TodoListId",
                        column: x => x.TodoListId,
                        principalTable: "TodoLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
#pragma warning restore SA1413 // Use trailing comma in multi-line initializers
#pragma warning restore CA1062 // Validate arguments of public methods
#pragma warning restore IDE0058 // Expression value is never used

#pragma warning disable IDE0058 // Expression value is never used
            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TodoListId",
                table: "Tasks",
                column: "TodoListId");
#pragma warning restore IDE0058 // Expression value is never used
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
#pragma warning disable IDE0058 // Expression value is never used
#pragma warning disable CA1062 // Validate arguments of public methods
            migrationBuilder.DropTable(
                name: "Tasks");
#pragma warning restore CA1062 // Validate arguments of public methods
#pragma warning restore IDE0058 // Expression value is never used
        }
    }
}
