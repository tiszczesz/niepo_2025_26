using cw5_partial.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IStudentsRepo,FakeStudentsRepo>();
builder.Services.AddSingleton<IDivisionRepo,FakeDivisionRepo>();
var app = builder.Build();
app.UseStaticFiles();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=First}/{action=List}/{id?}"
);

app.Run();
