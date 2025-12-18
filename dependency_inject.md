# Dependency Injection w ASP.NET Core

## Wprowadzenie

ASP.NET Core posiada wbudowany kontener **Dependency Injection (DI)**, który umożliwia luźne powiązanie komponentów aplikacji, ułatwia testowanie oraz poprawia architekturę kodu.

Konfiguracja usług odbywa się w pliku `Program.cs` przy użyciu obiektu `builder.Services`.

```csharp
var builder = WebApplication.CreateBuilder(args);
```

---

## Rejestrowanie usług

Usługi rejestruje się poprzez określenie **interfejsu**, **implementacji** oraz **czasu życia (lifetime)**.

```csharp
builder.Services.AddScoped<IMyService, MyService>();
```

---

## Czas życia usług (Service Lifetime)

ASP.NET Core udostępnia trzy podstawowe czasy życia usług:

---

## AddTransient

**Nowa instancja przy każdym użyciu**.

```csharp
builder.Services.AddTransient<IEmailService, EmailService>();
```

### Charakterystyka
- Nowa instancja przy każdym wstrzyknięciu
- Najkrótszy cykl życia

### Zastosowanie
- Lekkie, bezstanowe serwisy
- Klasy pomocnicze (np. walidatory, formatery)

### Wady
- Może generować dużą liczbę obiektów
- Nie nadaje się do kosztownych zasobów

---

## AddScoped

**Jedna instancja na jedno żądanie HTTP**.

```csharp
builder.Services.AddScoped<IOrderService, OrderService>();
```

### Charakterystyka
- Jedna instancja w obrębie jednego requestu
- Najczęściej używany lifetime

### Zastosowanie
- Serwisy biznesowe
- `DbContext` (Entity Framework Core)

### Zalety
- Bezpieczny w aplikacjach webowych
- Umożliwia współdzielenie stanu w jednym żądaniu

⚠️ **Uwaga:** Serwisy Scoped nie mogą być wstrzykiwane do Singletonów.

---

## AddSingleton

**Jedna instancja na całą aplikację**.

```csharp
builder.Services.AddSingleton<ICacheService, MemoryCacheService>();
```

### Charakterystyka
- Tworzony raz przy starcie aplikacji
- Współdzielony przez wszystkich użytkowników

### Zastosowanie
- Cache
- Konfiguracja
- Serwisy bezstanowe i thread-safe

### Wady
- Ryzyko problemów wielowątkowych
- Możliwe wycieki pamięci
- Nie należy przechowywać danych użytkownika

---

## Porównanie czasów życia

| Lifetime   | Liczba instancji | Zakres |
|------------|------------------|--------|
| Transient  | Zawsze nowa      | Każde użycie |
| Scoped     | Jedna            | Jedno żądanie HTTP |
| Singleton  | Jedna            | Cała aplikacja |

---

## Typowe błędy

- Wstrzykiwanie `DbContext` do Singletona
- Przechowywanie stanu użytkownika w Singletonie
- Brak thread-safety w Singletonach
- Nadużywanie Transient dla ciężkich obiektów

---

## Rekomendacje

- Domyślnie stosuj **AddScoped**
- **AddTransient** tylko dla lekkich klas
- **AddSingleton** wyłącznie dla serwisów bezstanowych
- Testuj lifetimes w testach integracyjnych

---

## Podsumowanie

Poprawne użycie Dependency Injection oraz odpowiedni dobór czasu życia usług ma kluczowe znaczenie dla wydajności, bezpieczeństwa i czytelności aplikacji ASP.NET Core.

