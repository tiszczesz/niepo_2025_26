using System;

namespace cw5_partial.Models;

public interface IStudentsRepo
{
    public IEnumerable<Student> GetStudents();
    public Student? GetStudent(int id);
    public void AddStudent(Student student);
    public void UpdateStudent(Student student);
    public void DeleteStudent(int id);
    
}
