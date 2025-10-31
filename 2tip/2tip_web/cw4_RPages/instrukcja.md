## Tworzenie aplikacji webowej
1. Utwórz projekt:
```console
dotnet new web -o nazwaAplikacji
cd nazwaAplikacji
code .
```

2. Przerabiamy plik Program.cs aby używał RazorPages
```cs
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
```
3. Dodajemy katalogi do projektu:
a. wwwroot
b. Pages

4. Dodajemy Stronę RazorPage Index
 wybieramy add file RazorPage w katalogu Pages

 5. Nową stronę dodajemy analogicznie w katalogu Pages

 6. Aby działały tagi asp-... to trzeba dodać do Pages plik _ViewImports
