using egzamin1.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

//dodanie CORS jesli potrzebne
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


var app = builder.Build();
//uzycie CORS jesli potrzebne
app.UseCors("AllowAll");

app.UseStaticFiles();
//app.MapGet("/", () => "Hello World!");
app.MapDefaultControllerRoute();
//czesc zwiazana z api
UsersRepo usersRepo = new UsersRepo();//utworz repozytorium
app.MapGet("/api/users", () => usersRepo.GetAllUsers());//pobierz wszystkich uzytkownikow
app.MapGet("/api/users/{id}",(int id) =>
{
    //pobierz uzytkownika o podanym id z repozytorium
    var user = usersRepo.GetUserById(id);
    if (user == null) //jesli nie znaleziono kod 404
    {
        return Results.NotFound();
    }
    //jesli znaleziono, zwroc uzytkownika kod 200
    return Results.Ok(user);
});
app.MapPost("/api/users", (User user) =>
{
    //dodaj uzytkownika do repozytorium
    usersRepo.AddUser(user);
    //zwroc kod 201
    return Results.Created($"/api/users/{user.Id}", user);
});
app.MapDelete("/api/users/{id}", (int id) =>
{    
    usersRepo.DeleteUser(id);
    return Results.NoContent();
});
app.Run();
