using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagement.Server.Migrations
{
    public partial class ProjectWorkerIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_catalog_project_workers_catalog_project_id",
                table: "catalog_project_workers");

            migrationBuilder.CreateIndex(
                name: "ix_catalog_project_workers_catalog_project_id_catalog_employee",
                table: "catalog_project_workers",
                columns: new[] { "catalog_project_id", "catalog_employee_id" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_catalog_project_workers_catalog_project_id_catalog_employee",
                table: "catalog_project_workers");

            migrationBuilder.CreateIndex(
                name: "ix_catalog_project_workers_catalog_project_id",
                table: "catalog_project_workers",
                column: "catalog_project_id");
        }
    }
}
