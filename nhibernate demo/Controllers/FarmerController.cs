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
    public class FarmerController : Controller
    {

        public ActionResult Index()
        {
            var repository = MvcApplication.container.Resolve<IFarmerRepository>();
            return View(repository.GetFarmers());
        }


        public ActionResult Details(int id)
        {
            return View();
        }


        public ActionResult Create()
        {
            return View();
        } 


        [HttpPost]
        public ActionResult Create(Farmer farmer)
        {
            try
            {

                var repository = MvcApplication.container.Resolve<IFarmerRepository>();
                repository.Save(farmer);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        public ActionResult Edit(int id)
        {
            var repository = MvcApplication.container.Resolve<IFarmerRepository>();

            return View(repository.GetByID(id));
        }

        [HttpPost]
        public ActionResult Edit(Farmer farmer)
        {
            try
            {
                var repository = MvcApplication.container.Resolve<IFarmerRepository>();
                repository.Save(farmer);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            var repository = MvcApplication.container.Resolve<IFarmerRepository>();
            repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
