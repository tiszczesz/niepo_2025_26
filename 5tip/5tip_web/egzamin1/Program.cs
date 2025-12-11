using egzamin1.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();
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
app.Run();
