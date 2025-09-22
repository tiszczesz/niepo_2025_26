using Nwd.ClassLib;

NwdCalculator calculator = new NwdCalculator();
var builder = WebApplication.CreateBuilder(args);
// Add services to the container. CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });
});
var app = builder.Build();
// Configure the HTTP request pipeline. CORS
app.UseCors();
app.MapGet("/", () => "Hello World!");

app.MapGet("/nwd/{a}/{b}", (int a, int b) => calculator.CalculateNwd(a, b));

app.Run();
