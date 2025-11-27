var builder = WebApplication.CreateBuilder(args);
//dodajemy obsługę kontrolerów
builder.Services.AddControllersWithViews();
var app = builder.Build();
//doddajemy obsługę plików statycznych css js img...
app.UseStaticFiles();

//dodajemy obsługę routingu Home/Index
app.MapDefaultControllerRoute();
//app.MapGet("/", () => "Hello World!");

app.Run();
