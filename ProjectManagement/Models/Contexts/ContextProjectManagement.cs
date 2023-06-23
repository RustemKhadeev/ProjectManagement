using Microsoft.EntityFrameworkCore;
using ProjectManagement.Server.Models.Models.Employees.Domain;
using ProjectManagement.Server.Models.Models.Projects.Domain;
using ProjectManagement.Server.Models.Models.ProjectTasks.Domain;
using ProjectManagement.Server.Models.Models.ProjectWorkers.Domain;

namespace ProjectManagement.Server.Models.Contexts
{
    public class ContextProjectManagement : DbContext
    {
        public DbSet<CatalogProject> CatalogProjects { get; set; }
        public DbSet<CatalogEmployee> CatalogEmployees { get; set; }
        public DbSet<CatalogProjectTask> CatalogProjectTasks { get; set; }

        public ContextProjectManagement(DbContextOptions<ContextProjectManagement> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogEmployee>().HasIndex(h => h.Id);
            modelBuilder.Entity<CatalogProject>().HasIndex(h => h.Id);
            modelBuilder.Entity<CatalogEmployee>()
                .HasMany(m => m.Projects)
                .WithMany(m => m.Employees)
                .UsingEntity<CatalogProjectWorker>(
                    e => e
                        .HasOne(o => o.CatalogProject)
                        .WithMany(m => m.ProjectWorkers)
                        .HasForeignKey(f => f.CatalogProjectId),
                    e => e
                        .HasOne(o => o.CatalogEmployee)
                        .WithMany(m => m.ProjectWorkers)
                        .HasForeignKey(f => f.CatalogEmployeeId),
                    e =>
                    {
                        e.HasKey(k => k.Id);
                        e.HasIndex(i => i.Id);
                        e.HasIndex(i => new
                        {
                            i.CatalogProjectId, i.CatalogEmployeeId
                        }).IsUnique();
                        e.ToTable("catalog_project_workers");
                    }); ;

            base.OnModelCreating(modelBuilder);
        }
    }
}
