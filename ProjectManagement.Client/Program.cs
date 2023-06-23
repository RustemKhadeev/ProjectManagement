using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ProjectManagement.Client;
using ProjectManagement.Client.Models.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddHttpClient("ProjectManagementServerAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:44315/");
    client.Timeout = TimeSpan.FromMinutes(5);
});
builder.Services.AddSingleton<CatalogEmployeeService>();
builder.Services.AddSingleton<CatalogProjectService>();
builder.Services.AddSingleton<CatalogProjectWorkerService>();
builder.Services.AddSingleton<CatalogProjectTaskService>();
builder.Services.AddAntDesign();

await builder.Build().RunAsync();
