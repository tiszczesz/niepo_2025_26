

namespace cw2_solution.web.Models;

public interface IStudentRepo
{
    Student? GetStudent(int id);
    List<Student> GetAllStudents();
}
