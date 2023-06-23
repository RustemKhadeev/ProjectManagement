﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProjectManagement.Server.Models.Contexts;

#nullable disable

namespace ProjectManagement.Server.Migrations
{
    [DbContext(typeof(ContextProjectManagement))]
    [Migration("20230623040158_ProjectWorkers")]
    partial class ProjectWorkers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProjectManagement.Server.Models.Models.Employees.Domain.CatalogEmployee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text")
                        .HasColumnName("middle_name");

                    b.HasKey("Id")
                        .HasName("pk_catalog_employees");

                    b.HasIndex("Id")
                        .HasDatabaseName("ix_catalog_employees_id");

                    b.ToTable("catalog_employees", (string)null);
                });

            modelBuilder.Entity("ProjectManagement.Server.Models.Models.Projects.Domain.CatalogProject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CustomerCompanyName")
                        .HasColumnType("text")
                        .HasColumnName("customer_company_name");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("end_date");

                    b.Property<string>("ExecutorCompanyName")
                        .HasColumnType("text")
                        .HasColumnName("executor_company_name");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("Priority")
                        .HasColumnType("integer")
                        .HasColumnName("priority");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_date");

                    b.HasKey("Id")
                        .HasName("pk_catalog_projects");

                    b.HasIndex("Id")
                        .HasDatabaseName("ix_catalog_projects_id");

                    b.ToTable("catalog_projects", (string)null);
                });

            modelBuilder.Entity("ProjectManagement.Server.Models.Models.ProjectWorkers.Domain.CatalogProjectWorker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CatalogEmployeeId")
                        .HasColumnType("integer")
                        .HasColumnName("catalog_employee_id");

                    b.Property<int>("CatalogProjectId")
                        .HasColumnType("integer")
                        .HasColumnName("catalog_project_id");

                    b.HasKey("Id")
                        .HasName("pk_catalog_project_workers");

                    b.HasIndex("CatalogEmployeeId")
                        .HasDatabaseName("ix_catalog_project_workers_catalog_employee_id");

                    b.HasIndex("CatalogProjectId")
                        .HasDatabaseName("ix_catalog_project_workers_catalog_project_id");

                    b.HasIndex("Id")
                        .HasDatabaseName("ix_catalog_project_workers_id");

                    b.ToTable("catalog_project_workers", (string)null);
                });

            modelBuilder.Entity("ProjectManagement.Server.Models.Models.ProjectWorkers.Domain.CatalogProjectWorker", b =>
                {
                    b.HasOne("ProjectManagement.Server.Models.Models.Employees.Domain.CatalogEmployee", "CatalogEmployee")
                        .WithMany("ProjectWorkers")
                        .HasForeignKey("CatalogEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_catalog_project_workers_catalog_employees_catalog_employee_");

                    b.HasOne("ProjectManagement.Server.Models.Models.Projects.Domain.CatalogProject", "CatalogProject")
                        .WithMany("ProjectWorkers")
                        .HasForeignKey("CatalogProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_catalog_project_workers_catalog_projects_catalog_project_id");

                    b.Navigation("CatalogEmployee");

                    b.Navigation("CatalogProject");
                });

            modelBuilder.Entity("ProjectManagement.Server.Models.Models.Employees.Domain.CatalogEmployee", b =>
                {
                    b.Navigation("ProjectWorkers");
                });

            modelBuilder.Entity("ProjectManagement.Server.Models.Models.Projects.Domain.CatalogProject", b =>
                {
                    b.Navigation("ProjectWorkers");
                });
#pragma warning restore 612, 618
        }
    }
}