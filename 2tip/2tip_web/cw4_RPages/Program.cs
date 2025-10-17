var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();
//Konfigurowanie potoku żądań HTTP.
app.UseStaticFiles();
// app.MapGet("/", () => "Hello World!");
// app.MapGet("/ggg", () => "<h1>Hello GGG!</h1>");
app.MapRazorPages();

app.Run();
