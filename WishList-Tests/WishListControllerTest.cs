using Microsoft.AspNetCore.Mvc;
using WishList_RestService.Controllers;
using WishList_RestService.Models;
using WishList_RestService.Services;
using WishList_RestService.Validation;
using WishList_RestService.Validation.Impl;
using WishList_Tests.Utils;

namespace WishList_Tests
{
    public class WishListControllerTest
    {
        private readonly WishListController _controller;
        private readonly IWishService _service;
        private readonly IWishValidator _validator;

        public WishListControllerTest()
        {
            _service = new WishServiceFake();
            _validator = new WishValidator(_service);
            _controller = new WishListController(_service, _validator);
        }

        [Fact]
        public void GetWishes_WhenCalled_ReturnOkResponse()
        {
            //Act 
            var okResponse = _controller.GetWishes();

            //Assert
            Assert.IsType<OkObjectResult>(okResponse as OkObjectResult);
        }

        [Fact]
        public void GetWishes_WhenCalled_ReturnsAllWishes()
        {
            //Act 
            var okResponse = _controller.GetWishes() as OkObjectResult;

            //Assert
            var items = Assert.IsType<List<Wish>>(okResponse.Value);
            Assert.Equal(5, items.Count);
        }

        [Fact]
        public void GetWishById_ExistingIdPassed_ReturnRightWish()
        {
            //Arrange
            int id = 1; 

            //Act
            var okResponse = _controller.GetWishById(id) as OkObjectResult;

            //Assert
            Assert.IsType<Wish>(okResponse.Value);
            Assert.Equal(id, (okResponse.Value as Wish).Id);
        }

        [Fact]
        public void GetWishById_ExistingIdPassed_ReturnsOkResponse()
        {
            //Arrange
            int id = 1;

            //Act
            var okResponse = _controller.GetWishById(id);

            //Assert
            Assert.IsType<OkObjectResult>(okResponse as OkObjectResult);
        }

        [Fact]
        public void GetWishById_NotExistingIdPassed_ReturnsNotFoundResponse()
        {
            //Arrange
            int id = 90;

            //Act
            var noContentResponse = _controller.GetWishById(id);

            //Assert
            Assert.IsType<NoContentResult>(noContentResponse);
        }

        [Fact]
        public void AddWish_InvalidObjectPassed_ReturnsBadRequest()
        {
            //Arrange
            var nameMissingItem = new Wish()
            {   
                Description = "dsada"
            };
            _controller.ModelState.AddModelError("Name", "Required");

            //Act
            var badResponse = _controller.AddWish(nameMissingItem);

            //Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public void AddWish_ValidObjectPassed_ReturnsCreatedRequest()
        {
            //Arrange
            var requestBody = new Wish()
            {
                Name = "Test",
                Description = "dsada"
            };

            //Act
            var createdResponse = _controller.AddWish(requestBody);

            //Assert
            Assert.IsType<CreatedResult>(createdResponse);
        }

        [Fact]
        public void AddWish_ValidObjectPassed_ReturnsAlreadyCreatedWish()
        {
            //Arrange
            var requestBody = new Wish() { Id = 1, Name = "Cookie", Description = "Buy Cookies" };

            //Act
            var responseBody = _controller.AddWish(requestBody);

            //Assert
            Assert.IsType<BadRequestObjectResult>(responseBody);
        }

        [Fact]
        public void AddWish_ValidObjectPassed_ReturnsWishLisCount()
        {
            //Arrange
            var requestBody = new Wish() {Name = "Game", Description = "Play LOL" };

            //Act
            _controller.AddWish(requestBody);
            var wishCount = _controller.GetWishes() as OkObjectResult;

            //Assert
            var items = Assert.IsType<List<Wish>>(wishCount.Value);
            Assert.Equal(6, items.Count);
        }

        [Fact]
        public void UpdateWishDescription_ValidObjectPassed_ReturnsOkResponse()
        {
            //Arrange
            int id = 1;
            var updateWish = new Wish()
            {
                Description = "Test"
            };

            //Act
            var updatedResponse = _controller.UpdateWish(updateWish, id);

            //Assert
            Assert.IsType<OkObjectResult>(updatedResponse);
            Assert.Equal(_service.GetWishById(1).Description, updateWish.Description);
        }

        [Fact]
        public void UpdateWishName_ValidObjectPassed_ReturnsOkResponse()
        {
            //Arrange
            int id = 1;
            var updateWish = new Wish()
            {
                Name = "Test"
            };

            //Act
            var updatedResponse = _controller.UpdateWish(updateWish, id);

            //Assert
            Assert.IsType<OkObjectResult>(updatedResponse);
            Assert.Equal(_service.GetWishById(1).Name, updateWish.Name);
        }

        [Fact]
        public void UpdateFullWish_ValidObjectPassed_ReturnsAlreadyCreatedWish()
        {
            //Arrange
            int id = 1;
            var updateWish = new Wish()
            {
                Name = "Test",
                Description = "Test"
            };

            //Act
            var updatedResponse = _controller.UpdateWish(updateWish, id);

            //Assert
            Assert.IsType<OkObjectResult>(updatedResponse);
            Assert.Equal(_service.GetWishById(1).Name, updateWish.Name);
            Assert.Equal(_service.GetWishById(1).Description, updateWish.Description);
        }

        [Fact]
        public void UpdateWish_InvalidObjectPassed_ReturnsBadRequest()
        {
            //Arrange
            int id = 1;
            var updateWish = new Wish()
            {
                Name = "",
                Description = ""
            };

            //Act
            var badResponse = _controller.UpdateWish(updateWish, id);

            //Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public void UpdateWish_NotExistingIdPassed_ReturnsBadRequest()
        {
            //Arrange
            int id = 10;
            var updateWish = new Wish()
            {
                Name = "Test",
                Description = "Test"
            };

            //Act
            var badResponse = _controller.UpdateWish(updateWish, id);

            //Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public void DeleteWish_NotExistingIdPassed_ReturnsBadRequestResponse()
        {
            //Arrange
            int id = 10;

            //Act
            var badResponse = _controller.DeleteWish(id);

            //Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public void DeleteWish_ExistingIdPassed_ReturnsOkResponse()
        {
            //Arrange
            int id = 1;

            //Act
            var okResponse = _controller.DeleteWish(id);

            //Assert
            Assert.IsType<OkObjectResult>(okResponse);
        }

        [Fact]
        public void DeleteWish_ExistingIdPassed_RemovesOneWish()
        {
            //Arrange
            int id = 1;

            //Act
            var okResponse = _controller.DeleteWish(id);

            //Assert
            Assert.IsType<OkObjectResult>(okResponse);
            Assert.Equal(4, _service.GetWishes().Count);
        }

        [Fact]
        public void DeleteWishes_RemovesAllWishes()
        {
            //Act
            _controller.DeleteWishes();

            //Assert
            Assert.Equal(0, _service.GetWishes().Count);
        }

        [Fact]
        public void DeleteWishes_RemovesAllWishes_ReturnsOkResponse()
        {
            //Act
            var okResponse = _controller.DeleteWishes();

            //Assert
            Assert.IsType<OkObjectResult>(okResponse);
        }
    }
}