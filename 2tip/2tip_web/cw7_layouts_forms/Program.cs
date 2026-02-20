var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseStaticFiles();

//app.MapGet("/", () => "Hello World!");
//app.MapDefaultControllerRoute();//Home/Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=MyUsers}/{action=List}/{id?}");
app.Run();
