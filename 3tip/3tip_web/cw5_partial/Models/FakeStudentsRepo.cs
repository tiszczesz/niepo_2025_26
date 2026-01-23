using System;

namespace cw5_partial.Models;

public class FakeStudentsRepo : IStudentsRepo
{
    private List<Student> _students = new List<Student>
    {
        new Student { Id = 1, FirstName = "John", LastName = "Doe", BirthDate = new DateTime(2000, 1, 1), DivisionId = 1 },
        new Student { Id = 2, FirstName = "Jane", LastName = "Smith", BirthDate = new DateTime(1999, 5, 15), DivisionId = 2 },
        new Student { Id = 3, FirstName = "Alice", LastName = "Johnson", BirthDate = new DateTime(2001, 3, 22), DivisionId = 5 },
        new Student { Id = 4, FirstName = "Bob", LastName = "Williams", BirthDate = new DateTime(2000, 6, 10), DivisionId = 3 },
        new Student { Id = 5, FirstName = "Emma", LastName = "Brown", BirthDate = new DateTime(1999, 8, 20), DivisionId = 6 },
        new Student { Id = 6, FirstName = "Charlie", LastName = "Davis", BirthDate = new DateTime(2001, 2, 14), DivisionId = 4 },
        new Student { Id = 7, FirstName = "Olivia", LastName = "Miller", BirthDate = new DateTime(2000, 10, 5), DivisionId = 1 },
        new Student { Id = 8, FirstName = "David", LastName = "Wilson", BirthDate = new DateTime(1999, 12, 28), DivisionId = 2 },
        new Student { Id = 9, FirstName = "Sophia", LastName = "Moore", BirthDate = new DateTime(2001, 4, 16), DivisionId = 1 },
        new Student { Id = 10, FirstName = "Michael", LastName = "Taylor", BirthDate = new DateTime(2000, 7, 9), DivisionId = 2 },
        new Student { Id = 11, FirstName = "Ava", LastName = "Anderson", BirthDate = new DateTime(1999, 11, 3), DivisionId = 6 },
        new Student { Id = 12, FirstName = "James", LastName = "Thomas", BirthDate = new DateTime(2001, 1, 25), DivisionId = 5 },
        new Student { Id = 13, FirstName = "Isabella", LastName = "Jackson", BirthDate = new DateTime(2000, 9, 17), DivisionId = 1 },
        new Student { Id = 14, FirstName = "William", LastName = "White", BirthDate = new DateTime(1999, 3, 11), DivisionId = 3 },
        new Student { Id = 15, FirstName = "Mia", LastName = "Harris", BirthDate = new DateTime(2001, 5, 8), DivisionId = 1 },
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
