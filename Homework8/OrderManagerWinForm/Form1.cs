using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderManager;

namespace OrderManagerWinForm
{
    public partial class Form1 : Form
    {
        OrderService orderService = null;
        String searchKey;
        public String SearchKey
        {
            get => searchKey;
            set => searchKey = value;
        }
        public Form1()
        {
            InitializeComponent();
            orderService = new OrderService();
            comboBox1.SelectedIndex = 0;
            orderBindingSource.DataSource = orderService.Orders;
            textBox1.DataBindings.Add("Text", this, "SearchKey");
            test();
        }

        void test()
        {
            Customer customer1 = new Customer("A");
            Customer customer2 = new Customer("B");
            Customer customer3 = new Customer("C");
            Customer customer4 = new Customer("D");
            Product product1 = new Product(01, "p1", 10);
            Product product2 = new Product(03, "p2", 15);
            Product product3 = new Product(06, "p3", 20);
            Order order1 = orderService.AddOrder(orderService.MakeOrder(customer1));
            Order order2 = orderService.AddOrder(orderService.MakeOrder(customer2));
            orderService.AddOrderItem(order1, new OrderItem(product1, 50));
            orderService.AddOrderItem(order2, new OrderItem(product2, 40));
            orderService.AddOrderItem(order2, new OrderItem(product3, 60));
        }

        private void QueryAll()
        {
            orderBindingSource.DataSource = orderService.Orders;
            orderBindingSource.ResetBindings(false);
        }

        private void button1_Click(object sender, EventArgs e)//搜索
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    orderBindingSource.DataSource = orderService.Orders;
                    break;
                case 1:
                    orderBindingSource.DataSource = orderService.QueryOrdersByProduct(SearchKey);
                    break;
                case 2:
                    orderBindingSource.DataSource = orderService.QueryOrdersByCustomer(SearchKey);
                    break;
                default:
                    break;
            }
            orderBindingSource.ResetBindings(true);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                String path = saveFileDialog1.FileName;
                orderService.Export(path);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                String path = openFileDialog1.FileName;
                orderService.Import(path);
                QueryAll();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
