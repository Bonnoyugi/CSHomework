using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OrderManager.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        OrderService orderService = new OrderService();
        //测试用数据
        Customer customer1 = new Customer("A");
        Customer customer2 = new Customer("B");
        Customer customer3 = new Customer("C");
        Customer customer4 = new Customer("D");
        Product product1 = new Product(01, "p1", 10);
        Product product2 = new Product(03, "p2", 15);
        Product product3 = new Product(06, "p3", 20);

        [TestInitialize()]
        public void init()
        {
            Order order1 = new Order(customer1);
            orderService.AddOrder(order1);
            Order order2 = new Order(customer2);
            orderService.AddOrder(order2);
            Order order3 = new Order(customer3);
            orderService.AddOrder(order3);
            Order order4 = new Order(customer4);
            orderService.AddOrder(order4);
        }

        [TestMethod()]
        public void AddOrderTest()
        {
            Order order5 = new Order(customer1);
            orderService.AddOrder(order5);
        }

        [TestMethod()]
        [ExpectedException(typeof(ApplicationException))]
        public void AddOrderTest2()
        {
            Order order5 = new Order(customer1);
            orderService.AddOrder(order5);
        }

        [TestMethod()]
        public void DeleteOrderTest()
        {
            Order order5 = new Order(customer1);
            orderService.AddOrder(order5);
            int n = orderService.Count;
            orderService.DeleteOrder(order5);
            Assert.AreEqual(n, orderService.Count);
        }

        [TestMethod()]
        public void DeleteOrderByIDTest()
        {
            int n = orderService.Count;
            orderService.DeleteOrderByID(1);
            Assert.AreEqual(n, orderService.Count);
        }

        //！（运行有问题，没写完）
    }
}