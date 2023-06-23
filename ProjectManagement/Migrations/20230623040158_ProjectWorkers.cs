using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProjectManagement.Server.Migrations
{
    public partial class ProjectWorkers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "catalog_project_workers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    catalog_employee_id = table.Column<int>(type: "integer", nullable: false),
                    catalog_project_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_catalog_project_workers", x => x.id);
                    table.ForeignKey(
                        name: "fk_catalog_project_workers_catalog_employees_catalog_employee_",
                        column: x => x.catalog_employee_id,
                        principalTable: "catalog_employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_catalog_project_workers_catalog_projects_catalog_project_id",
                        column: x => x.catalog_project_id,
                        principalTable: "catalog_projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_catalog_project_workers_catalog_employee_id",
                table: "catalog_project_workers",
                column: "catalog_employee_id");

            migrationBuilder.CreateIndex(
                name: "ix_catalog_project_workers_catalog_project_id",
                table: "catalog_project_workers",
                column: "catalog_project_id");

            migrationBuilder.CreateIndex(
                name: "ix_catalog_project_workers_id",
                table: "catalog_project_workers",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "catalog_project_workers");
        }
    }
}
