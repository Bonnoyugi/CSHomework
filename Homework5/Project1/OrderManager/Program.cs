using System;

namespace OrderManager
{
    class Program
    {
        static void Main()
        {
            //测试用数据
            Customer customer1 = new Customer("A");
            Customer customer2 = new Customer("B");
            Customer customer3 = new Customer("C");
            Customer customer4 = new Customer("D");
            Product product1 = new Product(01, "p1", 10);
            Product product2 = new Product(03, "p2", 15);
            Product product3 = new Product(06, "p3", 20);
            //测试
            OrderService orderService = new OrderService();
            try
            {
                Order order1 = new Order(customer1);
                orderService.AddOrder(order1);
                Order order2 = new Order(customer2);
                orderService.AddOrder(order2);
                Order order3 = new Order(customer3);
                orderService.AddOrder(order3);
                Order order4 = new Order(customer4);
                orderService.AddOrder(order4);
                Order order5 = new Order(customer1);
                orderService.AddOrder(order5);
                orderService.AddOrderItem(order1, new OrderItem(product1, 50));
                orderService.AddOrderItem(order1, new OrderItem(product2, 45));
                orderService.AddOrderItem(order1, new OrderItem(product3, 60));
                orderService.AddOrderItem(order2, new OrderItem(product1, 85));
                orderService.AddOrderItem(order2, new OrderItem(product2, 40));
                orderService.AddOrderItem(order5, new OrderItem(product3, 12, 70));
                orderService.AddOrderItem(order5, new OrderItem(product1, 21, 80));
                orderService.AddOrderItem(order4, new OrderItem(product2, 32, 100));
                orderService.AddOrderItem(order3, new OrderItem(product1, 5, 1000));
                System.Console.WriteLine("订单1的信息\n"+orderService.ShowOrderDetails(order1));
                System.Console.WriteLine("所有包含product1的订单的信息\n" + orderService.ShowAllOrdersOfProduct(product1));
                System.Console.WriteLine("所有customer1的订单的信息\n" + orderService.ShowAllOrdersOfCustomer(customer1));
                System.Console.WriteLine("未排序的所有订单信息\n" + orderService.ShowAllDetails());
                orderService.SortByAccout();
                System.Console.WriteLine("按金额排序后的所有订单信息\n"+orderService.ShowAllDetails());
                orderService.SortByOrderID();
                System.Console.WriteLine("按订单ID排序后的所有订单信息\n" + orderService.ShowAllDetails());
                System.Console.WriteLine("添加已经存在的订单\n");
                OrderItem orderItem = new OrderItem(product1, 20);
                orderService.AddOrderItem(order5, orderItem);
                Console.WriteLine("第一次添加成功\n");
                orderService.AddOrderItem(order5, orderItem);
            }
            catch(Exception e)
            {
                Console.WriteLine("第二次添加捕获到异常，异常信息为:\n");
                Console.WriteLine(e.ToString());
            }
        }
    }
}
