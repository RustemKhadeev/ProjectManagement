using Microsoft.EntityFrameworkCore;
using ProjectManagement.Server.Models.Contexts;
using ProjectManagement.Server.Models.Models.Employees.Interfaces;
using ProjectManagement.Server.Models.Models.Employees.Repositories;
using System.Reflection;
using Newtonsoft.Json;
using ProjectManagement.Server.Models.Models.Projects.Interfaces;
using ProjectManagement.Server.Models.Models.Projects.Repositories;
using ProjectManagement.Server.Models.Models.ProjectTasks.Interfaces;
using ProjectManagement.Server.Models.Models.ProjectWorkers.Interfaces;
using ProjectManagement.Server.Models.Models.ProjectWorkers.Repositories;
using ProjectManagement.Server.Models.Models.ProjectTasks.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

var templ = builder.Configuration.GetConnectionString("TEMPLATE");
var pmIp = builder.Configuration["PM_IP"];
var pmCtlg = builder.Configuration["PM_CTLG"];
var pmUsr = builder.Configuration["PM_USR"];
var pmPwd = builder.Configuration["PM_PWD"];

builder.Services.AddDbContext<ContextProjectManagement>(opts =>
{
    
    var cs = string.Format(templ, pmIp, pmCtlg, pmUsr, pmPwd);
    opts.UseLazyLoadingProxies();
    opts.UseNpgsql(cs, o =>
        {
            o.CommandTimeout(600);
            o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            o.MigrationsHistoryTable("__ef_migrations_history");
        })
        .UseSnakeCaseNamingConvention();
});

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IRepositoryCatalogEmployee, RepositoryCatalogEmployee>();
builder.Services.AddScoped<IRepositoryCatalogProject, RepositoryCatalogProject>();
builder.Services.AddScoped<IRepositoryCatalogProjectWorker, RepositoryCatalogProjectWorker>();
builder.Services.AddScoped<IRepositoryCatalogProjectTask, RepositoryCatalogProjectTask>();
builder.Services.AddCors();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
    options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
});

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();
app.UseCors(opt => opt.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        "default",
        "{controller}/{action}/{id?}");
});

app.MapRazorPages();

app.Run();
