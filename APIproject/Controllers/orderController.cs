using APIproject.model;
using APIproject.services;
using APIproject.services.APIproject.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace APIproject.Controllers
{
    [ApiController]
    [Route("order/[controller]")]
    public class orderController : ControllerBase
    {
        private readonly orderService orderService;

        public orderController(orderService orderService)
        {
            this.orderService = orderService;

        }

        [HttpGet]
        public ActionResult<IEnumerable<order>> GetOrders()
        {
            var orders = orderService.GetOrders();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public ActionResult<order> GetOrder(int id)
        {
            var order = orderService.GetOrder(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public ActionResult<Item> CreateOrder(order order)
        {
            var createdItem = orderService.CreateOrder(order);
            return CreatedAtAction(nameof(createdItem), new { id = createdItem.order_id }, createdItem);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, order order)
        {
            if (id != order.order_id)
            {
                return BadRequest();
            }

            var updatedOrder = orderService.UpdateOrder(order);
            if (updatedOrder == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var deletedOrder = orderService.DeleteOrder(id);
            if (deletedOrder == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}