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
    public class GrainController : Controller
    {
        
        public ActionResult Index()
        {
            var repo = MvcApplication.container.Resolve<IGrainRepository>();
            return View(repo.GetGrains());
        }

        public ActionResult Details(int id)
        {
            var repo = MvcApplication.container.Resolve<IGrainRepository>();
            return View(repo.GetGrains());
        }

       
        public ActionResult Create()
        {
            var famersRepo = MvcApplication.container.Resolve<IFarmerRepository>();
            ViewData["Farmers"] = famersRepo.GetFarmers().ToList();

            return View();
        } 

        [HttpPost]
        public ActionResult Create(Grain grain, int farmerID, string features)
        {
            try
            {
                var repo = MvcApplication.container.Resolve<IGrainRepository>();
                grain.Features.Clear();
                foreach(string feature in features.Split(','))
                {
                    grain.Features.Add(new Feature { Name = feature });
                }
                repo.Save(grain, farmerID);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
       
        public ActionResult Edit(int id)
        {
            var farmersRepo = MvcApplication.container.Resolve<IFarmerRepository>();
            ViewData["Farmers"] = farmersRepo.GetFarmers().ToList();

            var repo = MvcApplication.container.Resolve<IGrainRepository>(); 
            
            return View(repo.GetByID(id));
        }

        [HttpPost]
        public ActionResult Edit(Grain grain, int farmerID, string features)
        {
            try
            {
                var repo = MvcApplication.container.Resolve<IGrainRepository>();

                grain.Features.Clear();
                foreach (string feature in features.Split(','))
                {
                    grain.Features.Add(new Feature { Name = feature });
                }
                repo.Save(grain, farmerID);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            var repo = MvcApplication.container.Resolve<IGrainRepository>();
            repo.Delete(id);
            return RedirectToAction("Index");
        }

        
    }
}
