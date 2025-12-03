using System;
using Microsoft.EntityFrameworkCore;

namespace cw4_school2025.Models;

public class StudentContext: DbContext
{
    public StudentContext(DbContextOptions<StudentContext> options) : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //modelBuilder.Entity<Student>().ToTable("Student");
        //wstepne dane do tabelki Students
        modelBuilder.Entity<Student>().HasData();
    }
}
