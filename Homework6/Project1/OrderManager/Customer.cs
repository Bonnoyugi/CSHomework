using System;

namespace OrderManager
{
    [Serializable]
    public class Customer
    {
        private string name="Unknown Customer";

        public string Name
        {
            get => name;
            set => name = value;
        }

        public Customer()
        {
            Name = null;
        }

        public Customer(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
