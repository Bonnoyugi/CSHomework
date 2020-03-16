using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderManager
{
    class OrderService
    {
        private List<Order> orders = new List<Order>();

        //添加订单
        public void AddOrder(Order order)
        {
            if (orders.Exists(t => t == order))
                throw new System.ArgumentException("无法添加新的订单:订单已经存在");
            orders.Add(order);
        }

        //删除订单
        public void DeleteOrder(Order order)
        {
            if (!orders.Exists(t => t == order))
                throw new System.ArgumentException("无法删除订单:订单不存在");
            orders.Remove(order);
        }

        //通过订单ID删除订单
        public void DeleteOrderByID(int orderID)
        {
            if (!orders.Exists(t => t.OrderID == orderID))
                throw new System.ArgumentException("无法删除订单:订单ID不存在");
            orders.Remove(orders.Find(t => t.OrderID == orderID));
        }

        //为订单添加项
        public void AddOrderItem(Order order,OrderItem orderItem)
        {
            if (!orders.Exists(t => t == order))
                throw new System.ArgumentException("无法添加新的订单项:订单不存在");
            if (orders.Exists(t => t.orderItems.Exists(itemOfT => itemOfT == orderItem)))
                throw new System.ArgumentException("无法添加新的订单项:订单项已经存在");
            order.orderItems.Add(orderItem);
        }

        //为订单删除项
        public void DeleteOrderItem(Order order,OrderItem orderItem)
        {
            if (!orders.Exists(t => t == order))
                throw new System.ArgumentException("无法删除订单项:订单不存在");
            if (!orders.Exists(t => t.orderItems.Exists(itemOfT => itemOfT == orderItem)))
                throw new System.ArgumentException("无法删除订单项:订单项不存在");
            order.orderItems.Remove(orderItem);
        }

        //通过ID为订单删除项
        public void DeleteOrderItemByID(Order order, int orderItemID)
        {
            if (!orders.Exists(t => t == order))
                throw new System.ArgumentException("无法删除订单项:订单不存在");
            if (!orders.Exists(t => t.orderItems.Exists(itemOfT => itemOfT.OrderItemID == orderItemID)))
                throw new System.ArgumentException("无法删除订单项:订单项ID不存在");
            order.orderItems.Remove(order.orderItems.Find(itemOfT => itemOfT.OrderItemID == orderItemID));
        }

        //通过订单ID排序订单
        public void SortByOrderID()
        {
            orders.Sort();
        }

        //求订单金额
        static public int GetAccount(Order order)
        {
            int sum = 0;
            foreach (OrderItem orderItem in order.orderItems)
            {
                sum += orderItem.Price * orderItem.Quantity;
            }
            return sum;
        }

        //通过订单金额进行排序
        public void SortByAccout()
        {
            orders.Sort((order1, order2) => GetAccount(order1) - GetAccount(order2));
        }

        //对特定订单通过订单金额进行排序
        static public void SortByAccout(List<Order> orders)
        {
            orders.Sort((order1, order2) => GetAccount(order1) - GetAccount(order2));
        }

        //获取订单细节
        public string ShowOrderDetails(Order order)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(orders.Find(t => t == order).ToString() + "\n");
            stringBuilder.Append("总价："+GetAccount(order)+"\n");
            return stringBuilder.ToString();
        }

        //获取所有细节
        public string ShowAllDetails()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Order order in orders)
            {
                stringBuilder.Append(ShowOrderDetails(order));
            }
            return stringBuilder.ToString();
        }

        //查询所有客户customer的订单，按金额排序
        public string ShowAllOrdersOfCustomer(Customer customer)
        {
            IEnumerable<Order> query = from o in orders
                                       where o.Customer == customer
                                       select o;
            List<Order> targetOrders = query.ToList();
            SortByAccout(targetOrders);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Order order in targetOrders)
            {
                stringBuilder.Append(order.ToString()+"\n");
            }
            return stringBuilder.ToString();
        }

        //查询所有包含产品product的订单,按金额排序
        public string ShowAllOrdersOfProduct(Product product)
        {
            IEnumerable<Order> query = from o in orders
                                       where o.orderItems.Exists(t => t.Product == product)
                                       select o;
            List<Order> targetOrders = query.ToList();
            SortByAccout(targetOrders);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Order order in targetOrders)
            {
                stringBuilder.Append(order.ToString() + "\n");
            }
            return stringBuilder.ToString();
        }
    }
}
