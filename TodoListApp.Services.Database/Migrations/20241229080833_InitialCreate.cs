#pragma warning disable IDE0005 // Using directive is unnecessary.
using System;
#pragma warning restore IDE0005 // Using directive is unnecessary.
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoListApp.Services.Database.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
#pragma warning disable IDE0058 // Expression value is never used
#pragma warning disable SA1413 // Use trailing comma in multi-line initializers
#pragma warning disable CA1062 // Validate arguments of public methods
            migrationBuilder.CreateTable(
                name: "TodoLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoLists", x => x.Id);
                });
#pragma warning restore CA1062 // Validate arguments of public methods
#pragma warning restore SA1413 // Use trailing comma in multi-line initializers
#pragma warning restore IDE0058 // Expression value is never used
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
#pragma warning disable CA1062 // Validate arguments of public methods
#pragma warning disable IDE0058 // Expression value is never used
            migrationBuilder.DropTable(
                name: "TodoLists");
#pragma warning restore IDE0058 // Expression value is never used
#pragma warning restore CA1062 // Validate arguments of public methods
        }
    }
}
