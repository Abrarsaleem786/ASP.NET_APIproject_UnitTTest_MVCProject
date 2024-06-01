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
        private readonly IorderService _orderService;

        public orderController(IorderService orderService)
        {
            _orderService = orderService;

        }

        [HttpGet]
        public ActionResult<IEnumerable<order>> GetOrders()
        {
            var orders = _orderService.GetOrders();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public ActionResult<order> GetOrder(int id)
        {
            var order = _orderService.GetOrder(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public ActionResult<order> CreateOrder(order order)
        {
            var createdOrder = _orderService.CreateOrder(order);
            return CreatedAtAction(nameof(GetOrder), new { id = createdOrder.order_id }, createdOrder);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, order order)
        {
            if (id != order.order_id)
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