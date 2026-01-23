using System;

namespace cw5_partial.Models;

public class FakeStudentsRepo : IStudentsRepo
{
    private List<Student> _students = new List<Student>
    {
        new Student { Id = 1, FirstName = "John", LastName = "Doe", BirthDate = new DateTime(2000, 1, 1), DivisionId = 1 },
        new Student { Id = 2, FirstName = "Jane", LastName = "Smith", BirthDate = new DateTime(1999, 5, 15), DivisionId = 2 },
        new Student { Id = 3, FirstName = "Alice", LastName = "Johnson", BirthDate = new DateTime(2001, 3, 22), DivisionId = 1 }
    };
    public void AddStudent(Student student)
    {
        throw new NotImplementedException();
    }

    public void DeleteStudent(int id)
    {
        throw new NotImplementedException();
    }

    public Student? GetStudent(int id)
    {
        return _students.FirstOrDefault(s => s.Id == id);
    }

    public IEnumerable<Student> GetStudents()
    {
        return _students;
    }

    public void UpdateStudent(Student student)
    {
        throw new NotImplementedException();
    }
}
