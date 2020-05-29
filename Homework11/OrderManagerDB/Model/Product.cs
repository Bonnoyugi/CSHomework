using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagerDB.Model
{
    [Serializable]
    public class Product
    {
        private int productID;
        private string name;

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

        public Product()
        {
            ProductID = -1;
            Name = "Unknown";
        }

        public Product(int productID, string name)
        {
            ProductID = productID;
            Name = name;
        }

        public override string ToString()
        {
            return ProductID.ToString() + "\t" + Name.ToString();
        }

        //public override bool Equals()
        //public override int GetHashCode()
    }
}
