using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using nhibernate_demo.Repositories;
using nhibernate_demo.Models;
using Autofac;

namespace nhibernate_demo.Controllers
{
    public class ChocolateBarController : Controller
    {
        //
        // GET: /ChocolatBar/

        public ActionResult Index()
        {
            var repo = MvcApplication.container.Resolve<IChocolateBarRepository>();
            return View(repo.GetChocolateBars());
        }

        //
        // GET: /ChocolatBar/Details/5

        public ActionResult Details(int id)
        {
            var repo = MvcApplication.container.Resolve<IChocolateBarRepository>();
            return View(repo.GetChocolateBars());
        }

        //
        // GET: /ChocolatBar/Create

        public ActionResult Create()
        {
            var chocolatiersRepo = MvcApplication.container.Resolve<IChocolatierRepository>();
            ViewData["Chocolatiers"] = chocolatiersRepo.GetChocolatiers().ToList();

            return View();
        } 

        //
        // POST: /ChocolatBar/Create

        [HttpPost]
        public ActionResult Create(ChocolateBar chocolateBar, int chocolatierID, string features)
        {
            try
            {
                var repo = MvcApplication.container.Resolve<IChocolateBarRepository>();
                chocolateBar.Features.Clear();
                foreach(string feature in features.Split(','))
                {
                    chocolateBar.Features.Add(new Feature { Name = feature });
                }
                repo.Save(chocolateBar, chocolatierID);

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
            var chocolatiersRepo = MvcApplication.container.Resolve<IChocolatierRepository>();
            ViewData["Chocolatiers"] = chocolatiersRepo.GetChocolatiers().ToList();

            var repo = MvcApplication.container.Resolve<IChocolateBarRepository>(); //MvcApplication.container.Resolve<IChocolateBarRepository>();
            
            return View(repo.GetByID(id));
        }

        //
        // POST: /ChocolatBar/Edit/5

        [HttpPost]
        public ActionResult Edit(ChocolateBar chocolateBar, int chocolatierID, string features)
        {
            try
            {
                var repo = MvcApplication.container.Resolve<IChocolateBarRepository>();

                chocolateBar.Features.Clear();
                foreach (string feature in features.Split(','))
                {
                    chocolateBar.Features.Add(new Feature { Name = feature });
                }
                repo.Save(chocolateBar, chocolatierID);
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
            var repo = MvcApplication.container.Resolve<IChocolateBarRepository>();
            repo.Delete(id);
            return RedirectToAction("Index");
        }

        
    }
}
