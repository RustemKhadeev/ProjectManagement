using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagement.Server.Migrations
{
    public partial class AddTaskExecutorAndAutor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "autor_id",
                table: "catalog_project_tasks",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "executor_id",
                table: "catalog_project_tasks",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_catalog_project_tasks_autor_id",
                table: "catalog_project_tasks",
                column: "autor_id");

            migrationBuilder.CreateIndex(
                name: "ix_catalog_project_tasks_executor_id",
                table: "catalog_project_tasks",
                column: "executor_id");

            migrationBuilder.AddForeignKey(
                name: "fk_catalog_project_tasks_catalog_employees_autor_id",
                table: "catalog_project_tasks",
                column: "autor_id",
                principalTable: "catalog_employees",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_catalog_project_tasks_catalog_employees_executor_id",
                table: "catalog_project_tasks",
                column: "executor_id",
                principalTable: "catalog_employees",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_catalog_project_tasks_catalog_employees_autor_id",
                table: "catalog_project_tasks");

            migrationBuilder.DropForeignKey(
                name: "fk_catalog_project_tasks_catalog_employees_executor_id",
                table: "catalog_project_tasks");

            migrationBuilder.DropIndex(
                name: "ix_catalog_project_tasks_autor_id",
                table: "catalog_project_tasks");

            migrationBuilder.DropIndex(
                name: "ix_catalog_project_tasks_executor_id",
                table: "catalog_project_tasks");

            migrationBuilder.DropColumn(
                name: "autor_id",
                table: "catalog_project_tasks");

            migrationBuilder.DropColumn(
                name: "executor_id",
                table: "catalog_project_tasks");
        }
    }
}
