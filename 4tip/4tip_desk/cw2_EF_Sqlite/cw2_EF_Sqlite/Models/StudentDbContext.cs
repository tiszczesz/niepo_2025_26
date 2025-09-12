using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace cw2_EF_Sqlite.Models
{
    public class StudentDbContext: DbContext {
        private string connString = "Data Source=students.db";
        
        //konigurujemy kontekst
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(connString);
        }

        //reprezentacja tabeli w bazie danych
        public DbSet<Student> Students { get; set; }

        //dane poczatkowe do modelu
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, FirstName = "Jan", LastName = "Kowalski", 
                    Group = "1A", CreatedAt = new DateTime(2025,2,12) },
                new Student { Id = 2, FirstName = "Anna", LastName = "Nowak",
                    Group = "2B", CreatedAt = new DateTime(2025, 4, 12)
                },
                new Student { Id = 3, FirstName = "Piotr", LastName = "Zieliński",
                    Group = "1A", CreatedAt = new DateTime(2025, 4, 22)
                }
            );
        }
    }
}
