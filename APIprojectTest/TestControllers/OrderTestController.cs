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
        public Mock<IOrderService> _serviceMock;
        public OrderController _controller;

        [TestInitialize]
        public void Setup()
        {
            _serviceMock = new Mock<IOrderService>();
            _controller = new OrderController(_serviceMock.Object);
        }
        [TestMethod]
        public void OrderController_GetItems_ReturnsOkResult()
        {
            //Arrange
            var order = new List<Order>
            {
                 new Order { orderID = 1, orderName = "pizzza", orderDetails = "large pizza" },
                new Order { orderID = 2, orderName = "rice", orderDetails = "plao" },
                new Order { orderID = 3, orderName = "burgers", orderDetails = "3 zinger burgers" }
            };
            _serviceMock.Setup(x => x.GetOrders()).Returns(order);

            //Act
            var actionResult = _controller.GetOrders();
            var okResult = actionResult.Result as OkObjectResult;
            List<Order> result = okResult.Value as List<Order>;

            //Assert
            Assert.AreEqual(result, order);
        }

        [TestMethod]
        public void OrderController_GetOrder_ByID()
        {

            //Arrange
            var order = new Order { orderID = 1, orderName = "pizza", orderDetails = "Large pizza" };
            _serviceMock.Setup(x => x.GetOrder(1)).Returns(order);

            //Act
            var actionResult = _controller.GetOrder(1);
            var okResult = actionResult.Result as OkObjectResult;
            Order result = okResult.Value as Order;

            //Assert
            Assert.AreEqual(result, order);
        }

        [TestMethod]
        public void OrderController_CreateOrder_ReturnsCreatedResponse()
        {
            //Arrange
            var order = new Order { orderID = 1, orderName = "pizza", orderDetails = "large pizza" };
            _serviceMock.Setup(x => x.CreateOrder(order)).Returns(order);

            //Act
            var actionResult = _controller.CreateOrder(order);
            var createdResult = actionResult.Result as CreatedAtActionResult;
            Order result = createdResult.Value as Order;

            //Assert
            Assert.AreEqual(result, order);
        }

        [TestMethod]
        public void OrderController_UpdateOrder_ReturnsOkResult()
        {
            //Arrange
            var order= new Order {orderID = 1, orderName = "pizza", orderDetails = "large pizza" };
            _serviceMock.Setup(x => x.UpdateOrder(1, order)).Returns(order);

            //Act
            var actionResult = _controller.UpdateOrder(1, order);
            var okResult = actionResult as OkObjectResult;
            Order result = okResult.Value as Order;

            //Assert
            Assert.AreEqual(result, order);
        }

        [TestMethod]
        public void OrderController_DeleteOrder_ReturnsOkResult()
        {
            //Arrange
            var order = new Order {orderID = 1, orderName = "pizza", orderDetails = "Large pizza" };
            _serviceMock.Setup(x => x.DeleteOrder(1)).Returns(order);

            //Act
            var actionResult = _controller.DeleteOrder(1);
            var okResult = actionResult as OkObjectResult;
            var result = okResult.Value as Order;

            //Assert
            Assert.AreEqual(result, order);
        }


    }
}
