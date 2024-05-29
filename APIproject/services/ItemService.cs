namespace APIproject.services
{
    using global::APIproject.model;
    using System.Collections.Generic;
    using System.Linq;

    namespace APIproject.Services
    {
        public interface IItemService
        {
            IEnumerable<Item> GetItems();
            Item GetItem(int id);
            Item CreateItem(Item item);
            Item UpdateItem(Item item);
            Item DeleteItem(int id);
        }
        public class ItemService : IItemService
        {
            private readonly List<Item> _items;

            public ItemService()
            {
                _items = new List<Item>();
                new List<Item>
                {
                    new Item { Id = 1, Name = "car", Description = "Lamborghini" },
                    new Item { Id = 2, Name = "toy", Description = "Aeroplane" },
                    new Item { Id = 3, Name = "chair", Description = "white chair" }
                }.ForEach(item => _items.Add(item));
            }

            public IEnumerable<Item> GetItems()
            {
                return _items;
            }

            public Item GetItem(int id)
            {
                return _items.FirstOrDefault(item => item.Id == id);
            }

            public Item CreateItem(Item item)
            {
                item.Id = _items.Count + 1;
                _items.Add(item);
                return item;
            }

            public Item UpdateItem(Item item)
            {
                var existingItem = _items.FirstOrDefault(i => i.Id == item.Id);
                if (existingItem == null)
                {
                    return null;
                }

                existingItem.Name = item.Name;
                existingItem.Description = item.Description;
                return existingItem;
            }

            public Item DeleteItem(int id)
            {
                var item = _items.FirstOrDefault(i => i.Id == id);
                if (item != null)
                {
                    _items.Remove(item);
                }
                return item;
            }
        }
    }
}
