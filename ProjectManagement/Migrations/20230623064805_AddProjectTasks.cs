using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProjectManagement.Server.Migrations
{
    public partial class AddProjectTasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "catalog_project_tasks",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    catalog_project_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_catalog_project_tasks", x => x.id);
                    table.ForeignKey(
                        name: "fk_catalog_project_tasks_catalog_projects_catalog_project_id",
                        column: x => x.catalog_project_id,
                        principalTable: "catalog_projects",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_catalog_project_tasks_catalog_project_id",
                table: "catalog_project_tasks",
                column: "catalog_project_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "catalog_project_tasks");
        }
    }
}
