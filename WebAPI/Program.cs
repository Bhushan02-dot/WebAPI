using Radzen;
using WebAPI.Client.Pages;
using WebAPI.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using City;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WebAPIContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("localDB") ?? throw new InvalidOperationException("Connection string 'WebAPIContext' not found.")));

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddRadzenComponents();
builder.Services.AddHttpClient();

builder.Services.AddControllers();  //add this whenever Controller is used.
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(WebAPI.Client._Imports).Assembly);
app.MapControllers(); // whenever Controller is used, Mapping is important 
app.Run();
