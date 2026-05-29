using web.app.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICompanyRepo,CompanyFakeRepo>();
//builder.Services.AddScoped<ICompanyRepo,CompanySqliteRepo>();
var app = builder.Build();

app.UseStaticFiles();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Company}/{action=Index}/{id?}");
app.Run();
