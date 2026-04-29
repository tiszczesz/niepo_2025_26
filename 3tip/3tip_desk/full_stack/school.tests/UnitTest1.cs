using school.classLib;

namespace school.tests;

public class StudentTest
{
    private List<Student> _students;
    [SetUp]
    public void Setup()
    {

        _students = new List<Student>
        { new Student
        {
            Id = 1,
            Firstname = "John",
            Lastname = "Doe",
            Email = "john.doe@example.com",
            BirthDate = DateOnly.FromDateTime(new DateTime(2000, 1, 1))
        },
        new Student
        {
            Id = 2,
            Firstname = "Jane",
            Lastname = "Smith",
            Email = "jane.smith@example.com",
            BirthDate = DateOnly.FromDateTime(new DateTime(2001, 2, 2))
        }
        };
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}
