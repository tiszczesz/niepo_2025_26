using System;
using Microsoft.EntityFrameworkCore;

namespace cw4_school2025.Models;

public class StudentContext: DbContext
{
    public StudentContext(DbContextOptions<StudentContext> options) : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //modelBuilder.Entity<Student>().ToTable("Student");
        //wstepne dane do tabelki Students
        modelBuilder.Entity<Student>().HasData(
            new Student
            {
                Id = 1,
                FirstName = "Jan",
                LastName = "Kowalski",
                BirthDate = new DateTime(1995, 05, 12),
                EctsPoints = 30
            },
            new Student
            {
                Id = 2,
                FirstName = "Anna",
                LastName = "Malewska",
                BirthDate = new DateTime(1996, 03, 22),
                EctsPoints = 12
            },
            new Student
            {
                Id = 3,
                FirstName = "Piotr",
                LastName = "Zalewski",
                BirthDate = new DateTime(1994, 11, 02),
                EctsPoints = 45
            }
        );
        modelBuilder.Entity<Teacher>().HasData(
            new Teacher
            {
                Id = 1,
                FirstName = "Jan",
                LastName = "Nowak",
                Salary = 5000
            },
            new Teacher
            {
                Id = 2,
                FirstName = "Anna",
                LastName = "Kowalska",
                Salary = 6000
            }
        );
    }
}
