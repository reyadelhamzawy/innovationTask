using innovationTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace innovationTask.Repository
{
    public class OrderRepository
    {
        private innovationTaskEntities ordersDbContext = new innovationTaskEntities();

        public List<Order> GetOrders()
        {
            return ordersDbContext.Orders.ToList();
        }

        public void InsertOrder(Order order)
        {
            ordersDbContext.Orders.Add(order);
            ordersDbContext.SaveChanges();
        }
    }
}