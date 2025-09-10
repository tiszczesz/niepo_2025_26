using Microsoft.EntityFrameworkCore;

namespace WinFormsEFSqLite.Models;

public class BooksDbContext : DbContext {
    private string connString = "Data Source=books.db";
    public DbSet<Book> Books { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlite(connString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Book>().HasData(
            new Book {
                Id = 1,
                Title = "Clean Code",
                Author = "Robert C. Martin",
                PubishDate = new DateTime(2008, 8, 1)
            },
            new Book {
                Id = 2,
                Title = "The Pragmatic Programmer",
                Author = "Andrew Hunt, David Thomas",
                PubishDate = new DateTime(1999, 10, 30)
            },
            new Book {
                Id = 3,
                Title = "Design Patterns",
                Author = "Erich Gamma et al.",
                PubishDate = new DateTime(1994, 10, 31)
            },
            new Book {
                Id = 4,
                Title = "Refactoring",
                Author = "Martin Fowler",
                PubishDate = new DateTime(1999, 7, 8)                                   
            }
        );
    }
}