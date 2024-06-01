using APIprojectMVC.Models;
using APIprojectMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Policy;

namespace APIprojectMVC.Controllers
{
    public class OrderController : Controller

    {
        public OrderServices orderServices;

        public OrderController(OrderServices orderServices)
        {
            this.orderServices= orderServices;
        }

        public async Task<IActionResult> Index()
        {
            List<OrderModel> items = await orderServices.GetOrders();
            return View(items);
        }
    }
}
