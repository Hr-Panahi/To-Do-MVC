using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList_MVC.Migrations
{
    /// <inheritdoc />
    public partial class AddTaskToDatabase2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "tblTasks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblTasks",
                table: "tblTasks",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tblTasks",
                table: "tblTasks");

            migrationBuilder.RenameTable(
                name: "tblTasks",
                newName: "Tasks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");
        }
    }
}
