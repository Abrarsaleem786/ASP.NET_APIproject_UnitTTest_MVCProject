using APIproject.model;
using APIproject.services;
using APIproject.services.APIproject.Services;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace servicesTestProject.ServicesTesting
{
    [TestClass]
    public class OrderService
    {
        [TestMethod]
        public void GetOrdersTest()
        {
            //Arrange
            var orderService = new APIproject.services.OrderService();
            //Act
            var orders = orderService.GetOrders();
            //Assert
            Assert.AreEqual(3, orders.Count());
        }
        [TestMethod]
        public void GetOrderByIdTest()
        {
            //Arrange
            var orderService = new APIproject.services.OrderService();
            //Act
            var order = orderService.GetOrder(1);
            //Assert
            Assert.AreEqual("pizza", order.orderName);
        }

        [TestMethod]
        public void CreateOrderTest()
        {
            //Arrange
            var orderService = new APIproject.services.OrderService();
            var order = new Order { orderID = 1, orderName = "pizza", orderDetails = "large pizza" };
            //Act
            var createdOrder = orderService.CreateOrder(order);
            //Assert
            Assert.AreEqual("pizza", createdOrder.orderName);
        }

        [TestMethod]
        public void UpdateOrderTest()
        {
            //Arrange
            var orderService = new APIproject.services.OrderService();
            var order = new Order { orderID = 1, orderName = "pizza", orderDetails = "large pizza" };
            //Act
            var updatedOrder = orderService.UpdateOrder(1, order);
            //Assert
            Assert.AreEqual("pizza", updatedOrder.orderName);
        }

        [TestMethod]
        public void DeleteOrderTest()
        {
            //Arrange
            var orderService = new APIproject.services.OrderService();
            //Act
            var order = orderService.DeleteOrder(1);
            //Assert
            Assert.AreEqual("pizza", order.orderName);
        }
    }
}
