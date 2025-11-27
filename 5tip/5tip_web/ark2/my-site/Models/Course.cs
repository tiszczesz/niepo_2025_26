using System;

namespace my_site.Models;

//jeden rekord z tabelki kursy
public class Course
{
    public int Id { get; set; }
    public string  CourseName { get; set; }
    public decimal Price { get; set; }
    public int MaxMembers { get; set; }
}
