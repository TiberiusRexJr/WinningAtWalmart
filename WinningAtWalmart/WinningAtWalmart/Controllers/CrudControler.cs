using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WinningAtWalmart.Models;
using WinningAtWalmart.DataLayer;

namespace WinningAtWalmart.Controllers
{
    public class CrudControler : Controller
    {
        // GET: CrudControler
        public ActionResult Index()
        {
            return View();
        }

        // GET: CrudControler/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CrudControler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CrudControler/Create
        [HttpPost]
        /*[ValidateAntiForgeryToken]*/
        public ActionResult Create(Worker worker)
        { 
            #region variables
        

        #endregion
        
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CrudControler/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CrudControler/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CrudControler/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CrudControler/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
