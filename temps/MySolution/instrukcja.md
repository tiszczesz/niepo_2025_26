# Instrukcja dodania projektu unit test do rozwiązania .NET

1. Utwórz nowy projekt testowy:
   ```bash
   dotnet new xunit -n MySolution.Tests
   ```
2. Dodaj projekt testowy do rozwiązania:
   ```bash
   dotnet sln Mysolution.sln add MySolution.Tests/MySolution.Tests.csproj
   ```
3. Dodaj referencję do testowanego projektu:
   ```bash
   dotnet add MySolution.Tests/MySolution.Tests.csproj reference MySolution.Console/MySolution.Console.csproj
   ```

Po wykonaniu tych kroków możesz dodawać testy jednostkowe w projekcie `MySolution.Tests`.
