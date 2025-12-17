var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Włączenie obsługi plików statycznych
app.UseStaticFiles();

// Endpoint zwracający stronę HTML z Tailwind CSS
app.MapGet("/", () => Results.Content("""
<!DOCTYPE html>
<html lang="pl">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>.NET 9 + Tailwind CSS 4</title>
    <link href="/css/output.css" rel="stylesheet">
</head>
<body class="bg-gray-100">
    <div class="container mx-auto px-4 py-8">
        <div class="max-w-2xl mx-auto">
            <h1 class="text-4xl font-bold text-blue-600 mb-4">
                Witaj w .NET 9 + Tailwind CSS 4!
            </h1>
            <div class="bg-white rounded-lg shadow-lg p-6">
                <h2 class="text-2xl font-semibold text-gray-800 mb-3">
                    Przykładowa karta
                </h2>
                <p class="text-gray-600 mb-4">
                    To jest przykładowa aplikacja pokazująca integrację 
                    .NET 9 z Tailwind CSS 4.
                </p>
                <button class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded">
                    Kliknij mnie
                </button>
            </div>
            <div class="mt-6 grid grid-cols-1 md:grid-cols-3 gap-4">
                <div class="bg-green-500 text-white p-4 rounded-lg">
                    <h3 class="font-bold">Szybki</h3>
                    <p>Tailwind CSS jest bardzo wydajny</p>
                </div>
                <div class="bg-purple-500 text-white p-4 rounded-lg">
                    <h3 class="font-bold">Nowoczesny</h3>
                    <p>.NET 9 to najnowsza wersja</p>
                </div>
                <div class="bg-orange-500 text-white p-4 rounded-lg">
                    <h3 class="font-bold">Łatwy</h3>
                    <p>Prosta konfiguracja i użycie</p>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
""", "text/html"));

app.Run();
