using APIprojectMVC.Models;
using APIprojectMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Policy;

namespace APIprojectMVC.Controllers
{
    public class OrderController : Controller

    {
        public IOrderService _orderServices;

        public OrderController(IOrderService orderServices)
        {
            _orderServices= orderServices;
        }

        public async Task<IActionResult> Index()
        {
            List<OrdersModel> items = await _orderServices.GetAllOrders();
            return View(items);
        }
    }
}
