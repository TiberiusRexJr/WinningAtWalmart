using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Mvc;
using Mavis1.DataLayer;
using Mavis1.Models;

namespace Mavis1.Controllers
{
    public class HomeController : Controller
    {
        DataBase db = new DataBase();
        public ActionResult Index()
        {
            Worker worker = new Worker();
            DataBase db = new DataBase();
            worker.ShowAllWorkers=db.RetrieveAll();
            return View(worker);
        }
        public ActionResult AddUser(string firstname, string lastname, string email, string password)
        {
            //initialization
            
            string result = "Error! Try again!";
            if (firstname != null && lastname != null && email != null && password != null)
            {
                Worker worker = new Worker(firstname, lastname, email, password);
                string response = db.Create(worker);
                result = "Success! Welcome!"+response;
            }

            return Json(result);
        }
        /*
                public ActionResult AddUser(string firstname)
                {
                    string response = "not fowkring asshole"+firstname;
                    if (firstname != null)
                    {
                        response = "working finally" + firstname;
                    }
                    return Json(response);
                }*/

        public ActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public ActionResult Privacy()
        {
            return View();
        }

        /*[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }*/
    }
}
