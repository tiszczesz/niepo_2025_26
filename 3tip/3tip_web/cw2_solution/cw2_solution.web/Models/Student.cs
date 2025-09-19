namespace cw2_solution.web.Models;

public class Student
{
    public int Id { get; set; }
    public string? LastName { get; set; }
    public string? FirstName { get; set; }
    public DateOnly DateOfBirth { get; set; }
}
