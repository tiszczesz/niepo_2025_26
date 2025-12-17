# Krok po kroku: .NET 9 z Tailwind CSS 4

## Wprowadzenie
Ten przewodnik pokazuje jak utworzyć minimalną aplikację webową w .NET 9 i zintegrować ją z Tailwind CSS 4.

## Wymagania wstępne
- .NET SDK 9.0 lub nowszy
- Node.js (wersja 18 lub nowsza)
- npm (Node Package Manager)

## Sprawdzenie wersji

```console
dotnet --version
```
Powinno pokazać wersję 9.0.x lub wyższą

```console
node --version
npm --version
```

## Krok 1: Tworzenie nowego projektu .NET 9 Web

Utwórz nowy folder dla projektu i przejdź do niego:

```console
mkdir MojaAplikacjaTailwind
cd MojaAplikacjaTailwind
```

Utwórz nowy minimalny projekt webowy:

```console
dotnet new web
```

To polecenie utworzy minimalną aplikację ASP.NET Core Web z:
- `Program.cs` - główny plik aplikacji
- `appsettings.json` - konfiguracja aplikacji
- `MojaAplikacjaTailwind.csproj` - plik projektu

## Krok 2: Struktura katalogów

Utwórz strukturę katalogów dla plików statycznych i styli:

```console
mkdir wwwroot
mkdir wwwroot/css
mkdir wwwroot/js
```

## Krok 3: Inicjalizacja npm i instalacja Tailwind CSS 4

Zainicjuj projekt npm:

```console
npm init -y
```

Zainstaluj Tailwind CSS 4 oraz CLI:

```console
npm install -D tailwindcss @tailwindcss/cli
```

**Uwaga:** Tailwind CSS v4 ma uproszczoną konfigurację - nie wymaga pliku `tailwind.config.js`!

## Krok 4: Tworzenie pliku źródłowego CSS

W Tailwind CSS 4 konfiguracja jest znacznie prostsza!

Utwórz plik `wwwroot/css/input.css` z pojedynczą linią:

```css
@import "tailwindcss";
```

To wszystko! Tailwind CSS 4 automatycznie wykryje użyte klasy w plikach HTML/Razor.

## Krok 5: Konfiguracja skryptów npm

Edytuj `package.json` i dodaj skrypty do sekcji `"scripts"`:

```json
"scripts": {
  "build:css": "tailwindcss -i ./wwwroot/css/input.css -o ./wwwroot/css/output.css --minify",
  "watch:css": "tailwindcss -i ./wwwroot/css/input.css -o ./wwwroot/css/output.css --watch"
}
```

## Krok 6: Modyfikacja Program.cs

Edytuj `Program.cs` aby serwować pliki statyczne i dodać prostą stronę HTML:

```csharp
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
```

## Krok 7: Budowanie CSS z Tailwind

Uruchom proces budowania CSS:

```console
npm run build:css
```

Ten skrypt wygeneruje plik `wwwroot/css/output.css` z wszystkimi potrzebnymi stylami Tailwind.

Dla trybu deweloperskiego z automatycznym odświeżaniem:

```console
npm run watch:css
```

## Krok 8: Uruchomienie aplikacji

W nowym oknie terminala uruchom aplikację .NET:

```console
dotnet run
```

Lub dla trybu deweloperskiego z automatycznym przeładowaniem:

```console
dotnet watch run
```

Aplikacja będzie dostępna pod adresem: `http://localhost:5000` lub `https://localhost:5001`

## Krok 9: Weryfikacja

Otwórz przeglądarkę i przejdź do `http://localhost:5000`

Powinieneś zobaczyć:
- Niebieskie tło (bg-gray-100)
- Biały nagłówek z cieniem
- Kolorowe karty w układzie siatki
- Przycisk z efektem hover

## Workflow deweloperski

Dla wygodnej pracy otwórz dwa okna terminala:

**Terminal 1** - Tailwind CSS w trybie watch:
```console
npm run watch:css
```

**Terminal 2** - .NET w trybie watch:
```console
dotnet watch run
```

Teraz każda zmiana w HTML (w Program.cs) lub dodanie nowych klas Tailwind spowoduje:
- Automatyczne przebudowanie CSS (Terminal 1)
- Automatyczne przeładowanie aplikacji (Terminal 2)

## Dodatkowe opcje

### Tworzenie osobnego pliku HTML

Zamiast HTML w Program.cs, możesz utworzyć `wwwroot/index.html`:

```html
<!DOCTYPE html>
<html lang="pl">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>.NET 9 + Tailwind CSS 4</title>
    <link href="/css/output.css" rel="stylesheet">
</head>
<body class="bg-gray-100">
    <!-- Twoja treść tutaj -->
</body>
</html>
```

I zmodyfikować Program.cs:

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles();
app.UseDefaultFiles(); // Szuka index.html

app.Run();
```

### Optymalizacja produkcyjna

Dla wersji produkcyjnej, zbuduj zoptymalizowany CSS:

```console
npm run build:css
```

To utworzy zminifikowany plik CSS tylko z użytymi klasami.

## Podsumowanie

Gratulacje! Utworzyłeś aplikację .NET 9 z Tailwind CSS 4.

Kluczowe elementy:
1. ✅ Projekt .NET 9 Web (`dotnet new web`)
2. ✅ Tailwind CSS 4 zainstalowany przez npm
3. ✅ Automatyczne budowanie CSS
4. ✅ Pliki statyczne serwowane przez .NET
5. ✅ Responsywny interfejs użytkownika

## Kolejne kroki

- Dodaj więcej stron
- Użyj Razor Pages dla dynamicznych treści
- Eksperymentuj z różnymi komponentami Tailwind
- Dodaj JavaScript dla interaktywności
- Skonfiguruj Tailwind plugins (forms, typography, etc.)
