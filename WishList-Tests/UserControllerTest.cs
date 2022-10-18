using Microsoft.AspNetCore.Mvc;
using User_RestService.Controllers;
using User_RestService.Models;
using User_RestService.Services;
using User_RestService.Services.Impl;

namespace UserList.Test
{
    public class UserControllerTest
    {
        private readonly UserController _controller;
        private readonly IUserService _service;
        private readonly List<User> _userList;
        private readonly Users _users;

        public UserControllerTest()
        {
            _service = new UserService();
            _controller = new UserController(_service);
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
        }

        [Fact]
        public void GetNames_WhenCalled_ReturnsOkResponse()
        {
            //Act
            var okResponse = _controller.GetNames(_users);

            //Assert
            Assert.IsType<OkObjectResult>(okResponse as OkObjectResult);
        }

        [Fact]
        public void GetNames_GetStringWithNames_ReturnsOkResponse()
        {
            //Act 
            var okResponse = _controller.GetNames(_users) as OkObjectResult;

            //Assert
            Assert.Equal("John, Lily, Conny", okResponse.Value);
        }
    }
}
