using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BurgerKing.Models;
using BurgerKing.DataLayer;
using Newtonsoft.Json;
using System.Net;

namespace BurgerKing.Controllers
{
    public class HomeController : Controller
    {
        DataBase db = new DataBase();
        public ActionResult Index()
        {
            List<Customer> customers = db.RetrieveAll();
            return View(customers);
        }

        public ActionResult SaveOrder(string name, string address, Order[] orders)
        {

            if (Session["AdminLogin"].ToString() != "")
            {
                string result = "Error!Order is not Complete";
                if (name != null && address != null && orders != null)
                {
                    var CustomerId = Guid.NewGuid();
                    Customer customer = new Customer();
                    customer.CustomerId = CustomerId;
                    customer.Name = name;
                    customer.Address = address;
                    customer.Orders = orders;
                    customer.OrderDate = DateTime.Now;
                    db.Customers.Add(customer);

                    foreach (var order in orders)
                    {
                        Order o = new Order();
                        o.OrderId = new Guid();
                        o.ProductName = order.ProductName;
                        o.Quantity = order.Quantity;
                        o.Price = order.Price;
                        o.Amount = order.Amount;
                        o.CustomerId = CustomerId;
                        db.Orders.Add(o);

                    }
                    db.SaveChanges();
                    result = "Success! Order is complete!";


                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            /*return RedirectToAction("Login", "AdminPanel");*/

        }

        public ActionResult EditOrder(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", order.CustomerId);
            return View(order);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditOrder([Bind(Include = "OrderId,ProductName,Quantity,Price,Amount,CustomerId")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", order.CustomerId);
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCustomer(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCustomer([Bind(Include = "CustomerId,Name,Address,OrderDate")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers,"CustomerId","Name",customer.CustomerId);
        }
    }
}
