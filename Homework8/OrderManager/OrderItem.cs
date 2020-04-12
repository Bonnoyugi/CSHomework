using System;

namespace OrderManager
{
    [Serializable]
    public class OrderItem
    {
        static private int currentOrderItemCount = 0;
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

        private OrderItem(Product product)
        {
            Product = product;
            currentOrderItemCount++;
            orderItemID = currentOrderItemCount;
        }

        public OrderItem(Product product,int quantity):this(product)
        {
            Price = product.Price;
            Quantity = quantity;
        }

        public OrderItem(Product product,int price,int quantity):this(product)
        {
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
            return OrderItemID.ToString()+"\t产品:"+Product.Name.ToString()
                +"\t价格:"+Price.ToString()+"\t数量:"+Quantity.ToString();
        }
    }
}
