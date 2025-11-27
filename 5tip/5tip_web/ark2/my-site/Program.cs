using my_site.Models;

var builder = WebApplication.CreateBuilder(args);
//dodajemy obsługę kontrolerów
builder.Services.AddControllersWithViews();
var app = builder.Build();
//doddajemy obsługę plików statycznych css js img...
app.UseStaticFiles();
//var connectionString = builder.Configuration.GetConnectionString("mysql");
var repo = new CoursesRepo(builder.Configuration);
//dodajemy obsługę routingu Home/Index
app.MapDefaultControllerRoute();
//app.MapGet("/", () => "Hello World!");
app.MapGet("/api",()=>repo.GetAll());

app.Run();
