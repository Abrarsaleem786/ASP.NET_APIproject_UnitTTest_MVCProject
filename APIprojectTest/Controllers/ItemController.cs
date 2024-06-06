using APIproject.Controllers;
using APIproject.model;
using APIproject.services.APIproject.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace APIprojectTest.TestControllers
{
    [TestClass]
    public class ItemController
    {
        public Mock<IItemService> _serviceMock;
        public APIproject.Controllers.ItemController _controller;

        [TestInitialize]
        public void Setup()
        {
            _serviceMock = new Mock<IItemService>();
            _controller = new APIproject.Controllers.ItemController(_serviceMock.Object);
        }
        [TestMethod]
        public void ItemController_GetItems_ReturnsOkResult()
        {
            //Arrange
            var items = new List<Item>
          {
                new Item { Id = 1, Name = "car", Description = "Lamborghini" },
                new Item { Id = 2, Name = "toy", Description = "Aeroplane" },
                new Item { Id = 3, Name = "chair", Description = "white chair" }
            };
            _serviceMock.Setup(x => x.GetItems()).Returns(items);

            //Act
            var actionResult = _controller.GetItems();
            var okResult = actionResult.Result as OkObjectResult;
            List<Item> result = okResult.Value as List<Item>;

            //Assert
            Assert.AreEqual(result, items);
        }

        [TestMethod]
        public void ItemController_GetItem_ByID() {

            //Arrange
            var item = new Item { Id = 1, Name = "car", Description = "Lamborghini" };
            _serviceMock.Setup(x => x.GetItem(1)).Returns(item);

            //Act
            var actionResult = _controller.GetItem(1);
            var okResult = actionResult.Result as OkObjectResult;
            Item result = okResult.Value as Item;

            //Assert
            Assert.AreEqual(result, item);
        }

        [TestMethod]
        public void ItemController_CreateItem_ReturnsCreatedResponse()
        {
            //Arrange
            var item = new Item { Id = 1, Name = "car", Description = "Lamborghini" };
            _serviceMock.Setup(x => x.CreateItem(item)).Returns(item);

            //Act
            var actionResult = _controller.CreateItem(item);
            var createdResult = actionResult.Result as CreatedAtActionResult;
            Item result = createdResult.Value as Item;

            //Assert
            Assert.AreEqual(result, item);
        }

        [TestMethod]
        public void ItemController_UpdateItem_ReturnsOkResult()
        {
            //Arrange
            var item = new Item { Id = 1, Name = "car", Description = "Lamborghini" };
            _serviceMock.Setup(x => x.UpdateItem(1, item)).Returns(item);

            //Act
            var actionResult = _controller.UpdateItem(1, item);
            var okResult = actionResult as OkObjectResult;
            Item result = okResult.Value as Item;

            //Assert
            Assert.AreEqual(result, item);
        }

        [TestMethod]
        public void ItemController_DeleteItem_ReturnsOkResult()
        {
            //Arrange
            var item = new Item { Id = 1, Name = "car", Description = "Lamborghini" };
            _serviceMock.Setup(x => x.DeleteItem(1)).Returns(item);

            //Act
            var actionResult = _controller.DeleteItem(1);
            var okResult = actionResult as OkObjectResult;
            var result = okResult.Value as Item;

            //Assert
            Assert.AreEqual(result, item);
        }


    }
}
