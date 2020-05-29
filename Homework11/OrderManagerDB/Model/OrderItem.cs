using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagerDB.Model
{
    [Serializable]
    public class OrderItem
    {
        private readonly int orderItemID;
        private Product product;
        private int price;
        private int quantity;

        public int OrderItemID
        {
            get => orderItemID;
        }

        public Product Product
        {
            get => product;
            set => product = value;
        }

        public int Price
        {
            get => price;
            set => price = value;
        }

        public int Quantity
        {
            get => quantity;
            set => quantity = value;
        }

        public OrderItem() { }

        public OrderItem(int orderItemID, Product product, int price, int quantity)
        {
            this.orderItemID = orderItemID;
            Product = product;
            Price = price;
            Quantity = quantity;
        }

        public override bool Equals(object obj)
        {
            return obj is OrderItem t && t.GetHashCode() == GetHashCode();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(OrderItemID, Product, Price, Quantity);
        }

        public override string ToString()
        {
            return OrderItemID.ToString() + "\t产品:" + Product.Name.ToString()
                + "\t价格:" + Price.ToString() + "\t数量:" + Quantity.ToString();
        }
    }
}
