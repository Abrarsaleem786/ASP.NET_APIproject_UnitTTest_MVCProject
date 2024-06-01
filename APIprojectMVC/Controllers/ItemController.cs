using APIprojectMVC.Models;
using APIprojectMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Policy;

namespace APIprojectMVC.Controllers
{
    public class ItemController : Controller

    {
        public ItemServices itemServices;

       public ItemController(ItemServices itemServices)
        {
            this.itemServices = itemServices;
        }

        public async Task<IActionResult> Index()
        {
            List<ItemsModel> items = await itemServices.GetItems();
            return View(items);
        }

        public ActionResult Create()
        {
            return View();
        }



        
        
    }
}
