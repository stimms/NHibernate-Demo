using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using nhibernate_demo.Repositories;
using nhibernate_demo.Models;

namespace nhibernate_demo.Controllers
{
    public class ChocolatierController : Controller
    {
        //
        // GET: /Chocolatier/

        public ActionResult Index()
        {
            var repository = new ChocolatierRepository();
            return View(repository.GetChocolatiers());
        }

        //
        // GET: /Chocolatier/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Chocolatier/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Chocolatier/Create

        [HttpPost]
        public ActionResult Create(Chocolatier chocolatier)
        {
            try
            {

                var repository = new ChocolatierRepository();
                repository.Save(chocolatier);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Chocolatier/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Chocolatier/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Chocolatier/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Chocolatier/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
