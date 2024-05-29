using APIproject.model;

namespace APIproject.services
{
    public interface IorderService
    {
        IEnumerable<order> GetOrders();
        order GetOrder(int id);
        order CreateOrder(order order);
        order UpdateOrder(order order);
        order DeleteOrder(int id);
    }
    public class orderService : IorderService
    {
       
        private readonly List<order> _orders;

        public orderService()
        {
            _orders = new List<order>();
            new List<order>
            {
                new order { order_id = 1, order_name = "pizzza", order_details = "large pizza" },
                new order { order_id = 2, order_name = "rice", order_details = "plao" },
                new order { order_id = 3, order_name = "burgers", order_details = "3 zinger burgers" }
            }.ForEach(order => _orders.Add(order));
        }

        public IEnumerable<order> GetOrders()
        {
            return _orders;
        }

        public order GetOrder(int id)
        {
            return _orders.FirstOrDefault(order => order.order_id == id);
        }

        public order CreateOrder(order order)
        {
            order.order_id = _orders.Count + 1;
            _orders.Add(order);
            return order;
        }

        public order UpdateOrder(order order)
        {
            var existingOrder = _orders.FirstOrDefault(i => i.order_id == order.order_id);
            if (existingOrder == null)
            {
                return null;
            }

            existingOrder.order_name = order.order_name;
            existingOrder.order_details = order.order_details;
            return existingOrder;
        }

        public order DeleteOrder(int id)
        {
            var order = _orders.FirstOrDefault(i => i.order_id == id);
            if (order != null)
            {
                _orders.Remove(order);
            }
            return order;
        }
    }
}
