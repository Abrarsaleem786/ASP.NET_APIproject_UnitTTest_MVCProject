using APIproject.Controllers;
using APIproject.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
namespace ControllersTestUsingHttpClient.Controllers
{
    [TestClass]
    public class ItemControllerTest
    {
        private readonly HttpClient httpClient = new HttpClient();


        [TestMethod]
        public async Task getAllItems()
        {
            HttpClient httpClient = new HttpClient();
            // Define the endpoint path
            Uri uri = new("https://localhost:7230/item/Item");

            // Send a GET request to the endpoint
            HttpResponseMessage response = await httpClient.GetAsync(uri);

            // Read the response content
            var items = await response.Content.ReadAsStringAsync();

            // Perform assertions
            Assert.IsNotNull(items);
            // Additional assertions can be added here based on the expected response
        }
        [TestMethod]
        public async Task getItemById()
        {
            HttpClient httpClient = new HttpClient();
            // Define the endpoint path
            Uri uri = new("https://localhost:7230/item/Item/1");

            // Send a GET request to the endpoint
            HttpResponseMessage response = await httpClient.GetAsync(uri);


            // Read the response content
            var item = await response.Content.ReadAsStringAsync();

            // Perform assertions
            Assert.IsNotNull(item);
            // Additional assertions can be added here based on the expected response
        }
        [TestMethod]
        public async Task addItem()
        {
            HttpClient httpClient = new HttpClient();
            // Define the endpoint path
            Uri uri = new("https://localhost:7230/item/Item");

            // Create a new item object
            Item item = new Item
            {
                Id = 1,
                Name = "Item1",
                Description = "new added item"
            };

            // Serialize the item object to JSON
            string json = JsonSerializer.Serialize(item);

            // Create a new StringContent object with the JSON data
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            // Send a POST request to the endpoint with the JSON data
            HttpResponseMessage response = await httpClient.PostAsync(uri, content);


            // Read the response content
            var result = await response.Content.ReadAsStringAsync();

            // Perform assertions
            Assert.IsNotNull(result);
            // Additional assertions can be added here based on the expected response
        }
        [TestMethod]
        public async Task updateItem()
        {
            HttpClient httpClient = new HttpClient();
            // Define the endpoint path
            Uri uri = new("https://localhost:7230/item/Item/1");

            // Create a new item object with updated values
            Item item = new Item
            {
                Id = 1,
                Name = "Item1",
                Description = "new added item"
            };

            // Serialize the item object to JSON
            string json = JsonSerializer.Serialize(item);

            // Create a new StringContent object with the JSON data
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            // Send a PUT request to the endpoint with the JSON data
            HttpResponseMessage response = await httpClient.PutAsync(uri, content);


            // Read the response content
            var result = await response.Content.ReadAsStringAsync();

            // Perform assertions
            Assert.IsNotNull(result);
            // Additional assertions can be added here based on the expected response
        }
        [TestMethod]
        public async Task deleteItem()
        {
            HttpClient httpClient = new HttpClient();
            // Define the endpoint path
            Uri uri = new("https://localhost:7230/item/Item/1");

            // Send a DELETE request to the endpoint
            HttpResponseMessage response = await httpClient.DeleteAsync(uri);


            // Read the response content
            var result = await response.Content.ReadAsStringAsync();

            // Perform assertions
            Assert.IsNotNull(result);

        }



        [TestMethod]
        public async Task SaveJsonToFile()
        {
            HttpClient httpClient = new HttpClient();
            // Define the endpoint path
            Uri uri = new Uri("https://localhost:7230/item/Item");

            // Send a GET request to the endpoint
            HttpResponseMessage response = await httpClient.GetAsync(uri);

            // Read the response content
            var json = await response.Content.ReadAsStringAsync();

            // Save the JSON data to a file
            File.WriteAllText("items.txt", json);

            //ControllersTestUsingHttpClient\bin\Debug\net8.0 ->file Location

        }
    }

}
