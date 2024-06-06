using APIproject.model;
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
    public class ItemService
    {
        [TestMethod]
      public void GetItemsTest()
        {
            //Arrange
            var itemService = new APIproject.services.APIproject.Services.ItemService();
            //Act
            var items = itemService.GetItems();
            //Assert
            Assert.AreEqual(3, items.Count());
        }
        [TestMethod]
        public void GetItemByIdTest()
        {
            //Arrange
            var itemService = new APIproject.services.APIproject.Services.ItemService();
            //Act
            var item = itemService.GetItem(1);
            //Assert
            Assert.AreEqual("car", item.Name);
        }

        [TestMethod]
        public void CreateItemTest()
        {
            //Arrange
            var itemService = new APIproject.services.APIproject.Services.ItemService();
            var item = new Item { Name = "car", Description = "Lamborghini" };
            //Act
            var createdItem = itemService.CreateItem(item);
            //Assert
            Assert.AreEqual("car", createdItem.Name);
        }

        [TestMethod]
        public void UpdateItemTest()
        {
            //Arrange
            var itemService = new APIproject.services.APIproject.Services.ItemService();
            var item = new Item { Id = 1, Name = "car", Description = "Lamborghini" };
            //Act
            var updatedItem = itemService.UpdateItem(1, item);
            //Assert
            Assert.AreEqual("car", updatedItem.Name);
        }

        [TestMethod]
        public void DeleteItemTest() {
            //Arrange
            var itemService = new APIproject.services.APIproject.Services.ItemService();
            //Act
            var item = itemService.DeleteItem(1);
            //Assert
            Assert.AreEqual("car", item.Name);
        }
    }
}
