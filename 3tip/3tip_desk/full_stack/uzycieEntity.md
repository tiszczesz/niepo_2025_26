# Entity Framework Core + SQLite w solution

## Podział odpowiedzialności

| Projekt           | Co dodajemy                                    |
| ----------------- | ---------------------------------------------- |
| `school.classLib` | Modele/encje + `DbContext`                     |
| `school.api`      | Pakiety EF SQLite + rejestracja w `Program.cs` |

---

## Pakiety NuGet

### `school.classLib`

```
dotnet add package Microsoft.EntityFrameworkCore
```

### `school.api`

```
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design
```

---

## SchoolDbContext w `school.classLib`

```csharp
using Microsoft.EntityFrameworkCore;

public class SchoolDbContext : DbContext
{
    public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }

    public DbSet<Student> Students { get; set; }
}
```

---

## Rejestracja w `school.api/Program.cs`

```csharp
builder.Services.AddDbContext<SchoolDbContext>(options =>
    options.UseSqlite("Data Source=school.db"));
```

---

## Zalety takiego podziału

- DbContext w `classLib` jest niezależny od warstwy API
- Można reużyć kontekstu w `school.tests` (np. z `UseInMemoryDatabase`)
- Separacja odpowiedzialności zgodna z zasadami czystej architektury
