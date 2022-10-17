using User_RestService.Models;
using User_RestService.Services;
using User_RestService.Services.Impl;

namespace UserList.Test
{
    public class UserServiceTest
    {
        private readonly List<User> _userList;
        private readonly Users _users;
        private readonly IUserService _userService;
        public UserServiceTest()
        {
            _userList = new List<User>()
            {
                new User() {Type = "user", Id = 1, Name = "John", Email = "johnjey@gmail.com"},
                new User() {Type = "user", Id = 2, Name = "Lily", Email = "lilyjey@gmail.com"},
                new User() {Type = "user", Id = 3, Name = "Conny", Email = "connyjey@gmail.com"}
            };

            _users = new Users()
            {
                UsersList = _userList
            };

            _userService = new UserService();
        }

        [Fact]
        public void CollectNames_GetAllNames_ReturnsNames()
        {
            //Act
            var usersString = _userService.CollectNames(_users);

            //Assert
            Assert.Equal("John, Lily, Conny", usersString);
        }

        [Fact]
        public void CollectNames_GetAllNames_EmptyArrayReturnsEmptyString()
        {
            //Arrange
            _users.UsersList.Clear();

            //Act
            var usersString = _userService.CollectNames(_users);

            //Assert
            Assert.Equal("", usersString);
        }
    }
}