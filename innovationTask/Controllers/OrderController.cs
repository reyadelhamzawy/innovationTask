using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using innovationTask.Models;
using innovationTask.Repository;

namespace innovationTask.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderRepository dbOrder = new OrderRepository();

        public ActionResult Index()
        {
            return View(dbOrder.GetOrders());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                dbOrder.InsertOrder(order);
                return RedirectToAction("Index");
            }

            return View(order);
        }
    }
}
