using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagement.Server.Migrations
{
    public partial class FixTaskStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                table: "catalog_project_tasks",
                newName: "status_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status_id",
                table: "catalog_project_tasks",
                newName: "status");
        }
    }
}
