using APIproject.Controllers;
using APIproject.model;
using APIproject.services;
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
    public class OrderTestController
    {
        public Mock<IorderService> _serviceMock;
        public orderController _controller;

        [TestInitialize]
        public void Setup()
        {
            _serviceMock = new Mock<IorderService>();
            _controller = new orderController(_serviceMock.Object);
        }
        [TestMethod]
        public void OrderController_GetItems_ReturnsOkResult()
        {
            //Arrange
            var order = new List<order>
            {
                new order { order_id = 1, order_name = "pizza", order_details = "Large piza" },
                new order { order_id = 2, order_name = "rize", order_details = "plao" },
                new order { order_id= 3,  order_name = "burgers", order_details = "3 zinger burgers" }
            };
            _serviceMock.Setup(x => x.GetOrders()).Returns(order);

            //Act
            var actionResult = _controller.GetOrders();
            var okResult = actionResult.Result as OkObjectResult;
            List<order> result = okResult.Value as List<order>;

            //Assert
            Assert.AreEqual(result, order);
        }

        [TestMethod]
        public void OrderController_GetOrder_ByID()
        {

            //Arrange
            var order = new order { order_id = 1, order_name = "pizza", order_details = "Large pizza" };
            _serviceMock.Setup(x => x.GetOrder(1)).Returns(order);

            //Act
            var actionResult = _controller.GetOrder(1);
            var okResult = actionResult.Result as OkObjectResult;
            order result = okResult.Value as order;

            //Assert
            Assert.AreEqual(result, order);
        }

        [TestMethod]
        public void OrderController_CreateOrder_ReturnsCreatedResponse()
        {
            //Arrange
            var order = new order { order_id = 1, order_name = "pizza", order_details = "large pizza" };
            _serviceMock.Setup(x => x.CreateOrder(order)).Returns(order);

            //Act
            var actionResult = _controller.CreateOrder(order);
            var createdResult = actionResult.Result as CreatedAtActionResult;
            order result = createdResult.Value as order;

            //Assert
            Assert.AreEqual(result, order);
        }

        [TestMethod]
        public void OrderController_UpdateOrder_ReturnsOkResult()
        {
            //Arrange
            var order= new order {order_id = 1, order_name = "pizza", order_details = "large pizza" };
            _serviceMock.Setup(x => x.UpdateOrder(1, order)).Returns(order);

            //Act
            var actionResult = _controller.UpdateOrder(1, order);
            var okResult = actionResult as OkObjectResult;
            order result = okResult.Value as order;

            //Assert
            Assert.AreEqual(result, order);
        }

        [TestMethod]
        public void OrderController_DeleteOrder_ReturnsOkResult()
        {
            //Arrange
            var order = new order { order_id = 1, order_name = "pizza", order_details = "Large pizza" };
            _serviceMock.Setup(x => x.DeleteOrder(1)).Returns(order);

            //Act
            var actionResult = _controller.DeleteOrder(1);
            var okResult = actionResult as OkObjectResult;
            var result = okResult.Value as order;

            //Assert
            Assert.AreEqual(result, order);
        }


    }
}
