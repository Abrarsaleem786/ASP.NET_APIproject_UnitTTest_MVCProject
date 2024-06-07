using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ControllersTestUsingHttpClient.Controllers
{
    [TestClass]
    public class OrderControllerTest
    {
        private readonly HttpClient httpClient = new HttpClient();
        [TestMethod]
        public async Task getAllOrders()
        {
            // Define the endpoint path
            Uri uri = new("https://localhost:7230/order/Order");

            // Send a GET request to the endpoint
            HttpResponseMessage response = await httpClient.GetAsync(uri);

            // Ensure the request was successful
            response.EnsureSuccessStatusCode();

            // Read the response content
            var orders = await response.Content.ReadAsStringAsync();

            // Perform assertions
            Assert.IsNotNull(orders);
            // Additional assertions can be added here based on the expected response
        }
        [TestMethod]
        public async Task getOrderById()
        {
            // Define the endpoint path
            Uri uri = new("https://localhost:7230/order/Order/1");

            // Send a GET request to the endpoint
            HttpResponseMessage response = await httpClient.GetAsync(uri);

            // Ensure the request was successful
            response.EnsureSuccessStatusCode();

            // Read the response content
            var order = await response.Content.ReadAsStringAsync();

            // Perform assertions
            Assert.IsNotNull(order);
            // Additional assertions can be added here based on the expected response
        }
        [TestMethod]
        public async Task createOrder()
        {
            // Define the endpoint path
            Uri uri = new("https://localhost:7230/order/Order");

            // Create the request body
            var order = new
            {
                orderID = 1,
                 orderName= "pulao",
                orderDetails = "chicken pulao"
            };
            var json = JsonSerializer.Serialize(order);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            // Send a POST request to the endpoint
            HttpResponseMessage response = await httpClient.PostAsync(uri, data);

            // Ensure the request was successful
            response.EnsureSuccessStatusCode();

            // Read the response content
            var createdOrder = await response.Content.ReadAsStringAsync();

            // Perform assertions
            Assert.IsNotNull(createdOrder);
            // Additional assertions can be added here based on the expected response
        }
        [TestMethod]
        public async Task updateOrder()
        {
            // Define the endpoint path
            Uri uri = new("https://localhost:7230/order/Order/1");

            // Create the request body
            var order = new
            {
                orderID = 1,
                orderName = "pulao",
                orderDetails = "chicken pulao"
            };
            var json = JsonSerializer.Serialize(order);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            // Send a PUT request to the endpoint
            HttpResponseMessage response = await httpClient.PutAsync(uri, data);

            // Ensure the request was successful
            response.EnsureSuccessStatusCode();

            // Read the response content
            var updatedOrder = await response.Content.ReadAsStringAsync();

            // Perform assertions
            Assert.IsNotNull(updatedOrder);
            // Additional assertions can be added here based on the expected response
        }
        [TestMethod]
        public async Task deleteOrder()
        {
            // Define the endpoint path
            Uri uri = new("https://localhost:7230/order/Order/1");

            // Send a DELETE request to the endpoint
            HttpResponseMessage response = await httpClient.DeleteAsync(uri);

            // Ensure the request was successful
            response.EnsureSuccessStatusCode();

            // Read the response content
            var deletedOrder = await response.Content.ReadAsStringAsync();

            // Perform assertions
            Assert.IsNotNull(deletedOrder);
            // Additional assertions can be added here based on the expected response
        }
    }
}
