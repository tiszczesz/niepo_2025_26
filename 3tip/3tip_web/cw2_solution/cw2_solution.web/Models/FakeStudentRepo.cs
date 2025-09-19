

namespace cw2_solution.web.Models;

public class FakeStudentRepo : IStudentRepo
{
    private List<Student> _students;

    public FakeStudentRepo() {
        _students = new List<Student>
        {
            new Student { Id = 1, FirstName = "John", LastName = "Doe", DateOfBirth = new DateOnly(2000, 1, 1) },
            new Student { Id = 2, FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(2001, 2, 2) },
            new Student { Id = 3, FirstName = "Jim", LastName = "Brown", DateOfBirth = new DateOnly(2002, 3, 3) }
        };
    }
    public List<Student> GetAllStudents()
    {
        return _students;
    }

    public Student? GetStudent(int id)
    {
        return _students.FirstOrDefault(s => s.Id == id);
    }
}
