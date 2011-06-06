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
    public partial class FarmerController : Controller
    {

        public virtual ActionResult Index()
        {
            var repository = MvcApplication.container.Resolve<IFarmerRepository>();
            return View(repository.GetFarmers());
        }


        public virtual ActionResult Details(int id)
        {
            return View();
        }


        public virtual ActionResult Create()
        {
            return View();
        } 


        [HttpPost]
        public virtual ActionResult Create(Farmer farmer)
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

        public virtual ActionResult Edit(int id)
        {
            var repository = MvcApplication.container.Resolve<IFarmerRepository>();

            return View(repository.GetByID(id));
        }

        public virtual ActionResult GetBiggestFarmer(string pantColor)
        {

            return View();
        }

        [HttpPost]
        public virtual ActionResult Edit(Farmer farmer)
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


        public virtual ActionResult Delete(int id)
        {
            var repository = MvcApplication.container.Resolve<IFarmerRepository>();
            repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
