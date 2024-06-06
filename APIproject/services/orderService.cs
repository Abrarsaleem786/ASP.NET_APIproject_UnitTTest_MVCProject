using APIproject.model;

namespace APIproject.services
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrders();
        Order GetOrder(int id);
        Order CreateOrder(Order order);
        Order UpdateOrder(int id, Order order);
        Order DeleteOrder(int id);
    }
    public class OrderService : IOrderService
    {
       
        private readonly List<Order> _orders;

        public OrderService()
        {
            _orders = new List<Order>();
            new List<Order>
            {
                new Order { orderID = 1, orderName = "pizzza", orderDetails = "large pizza" },
                new Order { orderID = 2, orderName = "rice", orderDetails = "plao" },
                new Order { orderID = 3, orderName = "burgers", orderDetails = "3 zinger burgers" }
            }.ForEach(order => _orders.Add(order));
        }

        public IEnumerable<Order> GetOrders()
        {
            return _orders;
        }

        public Order GetOrder(int id)
        {
            return _orders.FirstOrDefault(order => order.orderID == id);
        }

        public Order CreateOrder(Order order)
        {
            order.orderID = _orders.Count + 1;
            _orders.Add(order);
            return order;
        }

        public Order UpdateOrder(int id, Order order)
        {
            var existingOrder = _orders.FirstOrDefault(i => i.orderID == order.orderID);
            if (existingOrder == null)
            {
                return null;
            }

            existingOrder.orderName = order.orderName;
            existingOrder.orderDetails = order.orderDetails;
            return existingOrder;
        }

        public Order DeleteOrder(int id)
        {
            var order = _orders.FirstOrDefault(i => i.orderID == id);
            if (order != null)
            {
                _orders.Remove(order);
            }
            return order;
        }
    }
}
