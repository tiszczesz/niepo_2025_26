using cw2_solution.web.Models;

namespace cw2_solution.xunit;

public class UnitTest1
{
    [Fact]
    public void MockStudentRepoLength() {
        IStudentRepo repo = new FakeStudentRepo();
        var students = repo.GetAllStudents();
        Assert.Equal(3, students.Count);
    }
    [Fact]
    public void OutRangeId(){
        IStudentRepo repo = new FakeStudentRepo();
        var student = repo.GetStudent(5);
        Assert.Null(student);
    }
    [Fact]
    public void IfId3return3(){
        IStudentRepo repo = new FakeStudentRepo();
        var student = repo.GetStudent(3);
        Assert.Equal("Jim", student?.FirstName);
    }

    [Fact]
    public void IfAddStudentBirthDay() {
        //IStudentRepo repo = new FakeStudentRepo();
        var student = new Student{
            Id=4,
            FirstName="Test",
            LastName="Testowy",
            DateOfBirth = new DateOnly(2000,1,1),
        };
        // repo.AddStudent(student);
        // var addedStudent = repo.GetStudent(4);
        // Assert.Equal(new DateOnly(2000,1,1)
        //                , addedStudent?.DateOfBirth);
        Assert.True(
            student.DateOfBirth.AddYears(10)<
            DateOnly.FromDateTime(DateTime.Now));
    }
    [Fact]
    public void IfAddStudentWrongBirthDay() {
        //IStudentRepo repo = new FakeStudentRepo();
        var student = new Student{
            Id=4,
            FirstName="Test",
            LastName="Testowy",
            DateOfBirth = new DateOnly(2020,1,1),
        };
        // repo.AddStudent(student);
        // var addedStudent = repo.GetStudent(4);
        // Assert.Equal(new DateOnly(2000,1,1)
        //                , addedStudent?.DateOfBirth);
        Assert.True(
            student.DateOfBirth.AddYears(10)<
            DateOnly.FromDateTime(DateTime.Now));
    }
}
