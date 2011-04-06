using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using nhibernate_demo.Repositories;
using nhibernate_demo.Models;

namespace nhibernate_demo.Controllers
{
    public class ChocolateBarController : Controller
    {
        //
        // GET: /ChocolatBar/

        public ActionResult Index()
        {
            ChocolateBarRepository repo = new ChocolateBarRepository();
            return View(repo.GetChocolateBars());
        }

        //
        // GET: /ChocolatBar/Details/5

        public ActionResult Details(int id)
        {
            ChocolateBarRepository repo = new ChocolateBarRepository();
            return View(repo.GetChocolateBars());
        }

        //
        // GET: /ChocolatBar/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /ChocolatBar/Create

        [HttpPost]
        public ActionResult Create(ChocolateBar chocolateBar)
        {
            try
            {
                ChocolateBarRepository repo = new ChocolateBarRepository();
                repo.Save(chocolateBar);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /ChocolatBar/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /ChocolatBar/Edit/5

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
        // GET: /ChocolatBar/Delete/5
 
        public ActionResult Delete(int id)
        {
            ChocolateBarRepository repo = new ChocolateBarRepository();
            repo.Delete(id);
            return RedirectToAction("Index");
        }

        
    }
}
