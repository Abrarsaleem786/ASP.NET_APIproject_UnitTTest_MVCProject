using APIproject.model;
using APIproject.services.APIproject.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace APIproject.Controllers
{
    [ApiController]
    [Route("item/[controller]")]      
    public class ItemController : ControllerBase
    {
        private readonly ItemService _itemService;

        public ItemController(ItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Item>> GetItems()
        {
            var items = _itemService.GetItems();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(int id)
        {
            var item = _itemService.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public ActionResult<Item> CreateItem(Item item)
        {
            var createdItem = _itemService.CreateItem(item);
            return CreatedAtAction(nameof(GetItem), new { id = createdItem.Id }, createdItem);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateItem(int id, Item item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            var updatedItem = _itemService.UpdateItem(item);
            if (updatedItem == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            var deletedItem = _itemService.DeleteItem(id);
            if (deletedItem == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}