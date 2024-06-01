using APIprojectMVC.Models;
using APIprojectMVC.Services;
using Newtonsoft.Json;
using System.Net.Http;

namespace APIprojectMVC.Services
{
    public interface IServices
    {
        public Task<List<ItemsModel>> GetItems();
    }

    public class ItemServices : IServices
    {
        public async Task<List<ItemsModel>> GetItems()
        {
            List<ItemsModel> items = new List<ItemsModel>();
            using (HttpClient httpClient = new HttpClient())
            {
                Uri Uri = new Uri("https://localhost:44392/item");
                httpClient.BaseAddress = Uri;
                HttpResponseMessage response = await httpClient.GetAsync(httpClient.BaseAddress + "/Item");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<List<ItemsModel>>(data);
                }
            }
            return items;
        }

    }
}
