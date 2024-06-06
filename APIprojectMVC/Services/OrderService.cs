using APIprojectMVC.Models;
using APIprojectMVC.Services;
using Newtonsoft.Json;

namespace APIprojectMVC.Services
{
    public interface IOrderService
    {
        public Task<List<OrdersModel>> GetAllOrders();
    }

    public class OrderService : IOrderService
    {
        public async Task<List<OrdersModel>> GetAllOrders()
        {
            List<OrdersModel> items = new List<OrdersModel>();
            using (HttpClient httpClient = new HttpClient())
            {
                Uri Uri = new Uri("https://localhost:44392/order");
                httpClient.BaseAddress = Uri;
                HttpResponseMessage response = await httpClient.GetAsync(httpClient.BaseAddress + "/Order");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<List<OrdersModel>>(data);
                }
            }
            return items;
        }
    }
}

