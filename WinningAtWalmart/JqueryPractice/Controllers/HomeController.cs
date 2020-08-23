using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using winning

namespace JqueryPractice.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult AddUser(string firstname, string lastname, string email, string password)
        {
            DatabaseGeneratedAttribute 
            string result = "Error! Try again!";
            if (firstname != null && lastname != null && email != null && password != null)
            {

            }
        }

    }
}
