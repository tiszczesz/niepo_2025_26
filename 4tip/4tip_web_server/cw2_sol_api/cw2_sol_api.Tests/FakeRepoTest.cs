using cw2_sol_api.Api.Models;
namespace cw2_sol_api.Tests
{
    public class FakeRepoTest
    {
        [Fact]
        public void If_is_correct_users_counts()
        {
            // Arrange
            var fakeRepo = new FakeUserRepo();

            // Act
            int userCount = fakeRepo.GetAllUsers().Count();

            // Assert
            Assert.Equal(3, userCount);
        }
        [Fact]
        public void If_user_lastname_is_correct()
        {
            // Arrange
            var fakeRepo = new FakeUserRepo();

            // Act
            var user = fakeRepo.GetUserById(2);

            // Assert
            Assert.Equal("Smith", user?.Lastname);
        }
        [Fact]
        public void If_user_is_added_correctly()
        {
            // Arrange
            var fakeRepo = new FakeUserRepo();
            var newUser = new User { Id = 4, Firstname = "Bob", Lastname = "Brown", Age = 22 };

            // Act
            fakeRepo.AddUser(newUser);
            var addedUser = fakeRepo.GetUserById(4);

            // Assert
            Assert.NotNull(addedUser);
            Assert.Equal("Bob", addedUser?.Firstname);
            Assert.True(fakeRepo.GetAllUsers().Count() == 4);
        }
    }
}
