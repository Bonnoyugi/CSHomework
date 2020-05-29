using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemController: ControllerBase
    {
        private readonly OrderContext orderDB;

        public OrderItemController(OrderContext context)
        {
            this.orderDB = context;
            IQueryable<Order> query = orderDB.Orders;
        }

        [HttpGet("{id}")]
        public ActionResult<OrderItem> GetOrderItem(int id)
        {
            var orderItem = orderDB.OrderItems.FirstOrDefault(i => i.ItemId == id);
            if (orderItem == null) {
                return NotFound();
            }
            return orderItem;
        }

        [HttpGet]
        public ActionResult<List<OrderItem>> GetOrderItems(string productName)
        {
            IQueryable<OrderItem> query = orderDB.OrderItems;
            if (productName != null) {
                query = query.Where(x => x.ProductName.Contains(productName));
            }
            return query.ToList();
        }

        [HttpGet("pageQuery")]
        public ActionResult<List<OrderItem>> queryOrderItem(string productName, int skip, int take)
        {
            IQueryable<OrderItem> query = orderDB.OrderItems;
            if (productName != null) {
                query = query.Where(x => x.ProductName.Contains(productName));
            }
            query = query.Skip(skip).Take(take);
            return query.ToList();
        }


        [HttpPost]
        public ActionResult<OrderItem> PostOrderItem(OrderItem orderItem)
        {
            try {
                orderDB.OrderItems.Add(orderItem);
                orderDB.SaveChanges();
            }
            catch (Exception e) {
                string error = e.InnerException != null ? e.InnerException.Message : e.Message;
                return BadRequest(error);
            }
            return orderItem;
        }

        [HttpPut("{id}")]
        public ActionResult<OrderItem> PutOrderItem(int id, OrderItem orderItem)
        {
            if (id != orderItem.ItemId) {
                return BadRequest("Do not modify id.");
            }
            try {
                orderDB.Entry(orderItem).State = EntityState.Modified;
                orderDB.SaveChanges();
            }
            catch (Exception e) {
                string error = e.InnerException != null ? e.InnerException.Message : e.Message;
                return BadRequest(error);
            }
            return NoContent();
        }


        [HttpDelete("{id}")]
        public ActionResult DeleteOrderItem(int id)
        {
            try {
                var orderItem = orderDB.OrderItems.FirstOrDefault(i => i.ItemId == id);
                if (orderItem != null) {
                    orderDB.Entry(orderItem).State = EntityState.Deleted;
                    orderDB.SaveChanges();
                }
            }
            catch (Exception e) {
                string error = e.InnerException != null ? e.InnerException.Message : e.Message;
                return BadRequest(error);
            }
            return NoContent();
        }

    }


}