using APIproject.model;
using APIproject.services;
using APIproject.services.APIproject.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace APIproject.Controllers
{
    [ApiController]
    [Route("order/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;

        }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrders()
        {
            var orders = _orderService.GetOrders();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(int id)
        {
            var order = _orderService.GetOrder(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public ActionResult<Order> CreateOrder(Order order)
        {
            var createdOrder = _orderService.CreateOrder(order);
            return CreatedAtAction(nameof(GetOrder), new { id = createdOrder.orderID }, createdOrder);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, Order order)
        {
            if (id != order.orderID)
            {
                return BadRequest();
            }

            var updatedOrder = _orderService.UpdateOrder(id,order);
            if (updatedOrder == null)
            {
                return NotFound();
            }

            return Ok(updatedOrder);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var deletedOrder = _orderService.DeleteOrder(id);
            if (deletedOrder == null)
            {
                return NotFound();
            }

            return Ok(deletedOrder);
        }
    }
}