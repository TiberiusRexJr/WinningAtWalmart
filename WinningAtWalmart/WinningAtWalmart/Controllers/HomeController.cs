using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WinningAtWalmart.DataLayer;
using WinningAtWalmart.Models;

namespace WinningAtWalmart.Controllers
{
    public class HomeController : Controller
    {
        DataBase db = new DataBase();
        public IActionResult Index()
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

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
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
