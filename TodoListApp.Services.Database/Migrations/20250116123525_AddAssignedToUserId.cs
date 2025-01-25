using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoListApp.Services.Database.Migrations
{
    public partial class AddAssignedToUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
#pragma warning disable IDE0058 // Expression value is never used
#pragma warning disable CA1062 // Validate arguments of public methods
            migrationBuilder.AddColumn<string>(
                name: "AssignedToUserId",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: true);
#pragma warning restore CA1062 // Validate arguments of public methods
#pragma warning restore IDE0058 // Expression value is never used
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
#pragma warning disable IDE0058 // Expression value is never used
#pragma warning disable CA1062 // Validate arguments of public methods
            migrationBuilder.DropColumn(
                name: "AssignedToUserId",
                table: "Tasks");
#pragma warning restore CA1062 // Validate arguments of public methods
#pragma warning restore IDE0058 // Expression value is never used
        }
    }
}
