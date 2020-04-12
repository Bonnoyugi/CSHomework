using System.Collections.Generic;
using System;
using System.Text;

namespace OrderManager
{
    [Serializable]
    public class Order:IComparable
    {
        static private int currentOrderCount = 0;
        private readonly int orderID;
        public List<OrderItem> orderItems;
        private Customer customer;

        public List<OrderItem> OrderItems
        {
            get => orderItems;
        }

        public int OrderID
        {
            get => orderID;
        }

        public Customer Customer
        {
            get => customer;
            set => customer = value;
        }

        public Order()
        {
            orderItems = new List<OrderItem>();
            currentOrderCount++;
            orderID = currentOrderCount;
        }
        public Order(Customer customer):this()
        {
            Customer = customer;
        }

        public override bool Equals(object obj)
        {
            return obj is Order targetOrder && targetOrder.GetHashCode() == GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder stringbuilder = new StringBuilder();
            stringbuilder.Append("订单号:"+OrderID.ToString());
            stringbuilder.Append("\n客户:" + OrderID.ToString());
            foreach (OrderItem orderItem in orderItems)
            {
                stringbuilder.Append("\n");
                stringbuilder.Append(orderItem.ToString());
            }
            return stringbuilder.ToString();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.OrderID, this.orderItems, this.Customer);
        }

        //默认按照订单号排序
        public int CompareTo(object obj)
        {
            if (!(obj is Order target))
                throw new System.ArgumentException("目标无法与订单号进行比较:目标不是一个订单");
            return this.OrderID.CompareTo(target.OrderID);
        }
    }
}
