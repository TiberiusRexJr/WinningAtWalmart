using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WinningAtWalmart.DataLayer;
using WinningAtWalmart.Models;

namespace WinningAtWalmart.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            Worker worker = new Worker();
            DataBase db = new DataBase();
            worker.ShowAllWorkers=db.RetrieveAll();
            return View(worker);
        }

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
