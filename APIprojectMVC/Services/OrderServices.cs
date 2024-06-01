using APIprojectMVC.Models;
using APIprojectMVC.Services;
using Newtonsoft.Json;

namespace APIprojectMVC.Services
{
    public interface OServices
    {
        public Task<List<OrderModel>> GetOrders();
    }

    public class OrderServices : OServices
    {
        public async Task<List<OrderModel>> GetOrders()
        {
            List<OrderModel> items = new List<OrderModel>();
            using (HttpClient httpClient = new HttpClient())
            {
                Uri Uri = new Uri("https://localhost:44392/order");
                httpClient.BaseAddress = Uri;
                HttpResponseMessage response = await httpClient.GetAsync(httpClient.BaseAddress + "/order");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<List<OrderModel>>(data);
                }
            }
            return items;
        }
    }
}

