using System;

namespace OrderManager
{
    [Serializable]
    public class Product
    {
        private int productID;
        private string name;
        private int price;

        public int ProductID
        {
            get => productID;
            set => productID = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Price
        {
            get => price;
            set => price = value;
        }

        public Product()
        {
            ProductID = -1;
            Name = "Unknown";
            Price = 0;
        }

        public Product(int productID, string name,int price)
        {
            ProductID = productID;
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return ProductID.ToString()+"\t"+Name.ToString();
        }

        //public override bool Equals()
        //public override int GetHashCode()
    }
}
