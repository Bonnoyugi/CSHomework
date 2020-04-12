using System.Collections.Generic;
using System;
using System.Text;

namespace OrderManager
{
    [Serializable]
    public class Order:IComparable
    {
        private int orderID;
        private List<OrderItem> orderItems = new List<OrderItem>();
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

        public Order() { }

        public Order(int ID):this()
        {
            orderID = ID;
            orderItems.Add(new OrderItem(new Product(-1, "null", 0), 0));
        }
        public Order(int ID, Customer customer):this(ID)
        {
            Customer = customer;
        }

        //public override bool Equals(object obj)
        //{
        //    return obj is Order targetOrder && targetOrder.GetHashCode() == GetHashCode();
        //}

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

        //更换引用后在System中找不到Hashcode这一项了，暂时去掉算了
        //public override int GetHashCode()
        //{
        //    return Hashcode.Combine(this.OrderID, this.orderItems, this.Customer);
        //}

        //默认按照订单号排序
        public int CompareTo(object obj)
        {
            if (!(obj is Order target))
                throw new System.ArgumentException("目标无法与订单号进行比较:目标不是一个订单");
            return this.OrderID.CompareTo(target.OrderID);
        }
    }
}
