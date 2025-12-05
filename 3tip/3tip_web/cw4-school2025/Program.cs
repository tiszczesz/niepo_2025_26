using cw4_school2025.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
//pobieramy connection string z appsettings.json
var connString = builder.Configuration.GetConnectionString("sqlite");
builder.Services.AddDbContext<StudentContext>(
    options => options.UseSqlite(connString)
);
var app = builder.Build();
app.UseStaticFiles();
//app.MapGet("/", () => "Hello World!");
app.MapDefaultControllerRoute();

app.Run();
