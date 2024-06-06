using APIprojectMVC.Models;
using APIprojectMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Policy;

namespace APIprojectMVC.Controllers
{
    public class ItemController : Controller

    {
        public IItemService _itemServices;

       public ItemController(IItemService itemServices)
        {
            _itemServices = itemServices;
        }

        public async Task<IActionResult> Index()
        {
            List<ItemsModel> items = await _itemServices.GetAllItems();
            return View(items);
        }

        



        
        
    }
}
