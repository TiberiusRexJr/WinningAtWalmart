using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using McDonalds.Models;
using System.Diagnostics.Eventing.Reader;
using McDonalds.DataLayer;
using System.Net;

namespace McDonalds.Controllers
{
    public class HomeController : Controller
    {
        DataBase db = new DataBase();
        public IActionResult Index()
        {
            List<Worker> workers = db.RetrieveAll();
            return View(workers);
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
                return Json(result, new Newtonsoft.Json.JsonSerializerSettings());
            }
            /*return RedirectToAction("Login", "AdminPanel");*/

        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        public ActionResult EditOrder(Guid? id)
        {
            if (id == null)
            {
                return StatusCode(400);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return StatusCode(401);
            }
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
