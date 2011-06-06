using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using nhibernate_demo.Repositories;
using nhibernate_demo.Models;
using Autofac;
using Newtonsoft.Json;
using nhibernate_demo.Maps;
using System.IO;
using nhibernate_demo.JsonSerialization;

namespace nhibernate_demo.Controllers
{
    public partial class GrainController : Controller
    {

        public virtual ActionResult Index()
        {
            var repo = MvcApplication.container.Resolve<IGrainRepository>();
            return View(repo.GetGrains().ToList());
        }

        
        public virtual ActionResult IndexJson()
        {
            var repo = MvcApplication.container.Resolve<IGrainRepository>();
            return new NewtonsoftJsonActionResult { Data = repo.GetGrains() };
        }

        public virtual ActionResult Details(int id)
        {
            var repo = MvcApplication.container.Resolve<IGrainRepository>();
            return View(repo.GetGrains());
        }


        public virtual ActionResult Create()
        {
            var famersRepo = MvcApplication.container.Resolve<IFarmerRepository>();
            ViewData["Farmers"] = famersRepo.GetFarmers().ToList();

            return View();
        }

        [HttpPost]
        public virtual ActionResult Create(Grain grain, int farmerID, string features)
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


        public virtual ActionResult Edit(int id)
        {
            var farmersRepo = MvcApplication.container.Resolve<IFarmerRepository>();
            ViewData["Farmers"] = farmersRepo.GetFarmers().ToList();

            var repo = MvcApplication.container.Resolve<IGrainRepository>();

            return View(repo.GetByID(id));
        }

        [HttpPost]
        public virtual ActionResult Edit(Grain grain, int farmerID, string features)
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


        public virtual ActionResult Delete(int id)
        {
            var repo = MvcApplication.container.Resolve<IGrainRepository>();
            repo.Delete(id);
            return RedirectToAction("Index");
        }

        public virtual ActionResult DeleteAjax(int id)
        {
            var repo = MvcApplication.container.Resolve<IGrainRepository>();
            repo.Delete(id);
            return new EmptyResult();
        }

        public virtual ActionResult CreateABunch()
        {
            //farmers
            List<Farmer> farmers = new List<Farmer>();
            foreach (string farmerName in new string[] { "John", "Mark", "Sally", "June", "Susan" })
            {
                var repository = MvcApplication.container.Resolve<IFarmerRepository>();
                var farmer = new Farmer { Name = farmerName };
                repository.Save(farmer);
                farmers.Add(farmer);
            }

            //features
            List<Feature> features = new List<Feature>();
            foreach (String featureName in new string[] { "Hybrid", "Drought Resistant", "Pseudocereal", "Cereal" })
            {
                var repository = MvcApplication.container.Resolve<IFeatureRepository>();
                var feature = new Feature{ Name = featureName};
                repository.Save(feature);
                features.Add(feature);
            }

            //grains
            foreach (string grainName in new string[] { "Barley", "Wheat", "Maize", "Millet", "Oats", "Rye", "Triticale" })
            {
                var repository = MvcApplication.container.Resolve<IGrainRepository>();
                repository.Save(new Grain { Name = grainName, Features = GetRandomFeatures(features) }, GetRandomFamerID(farmers));
            }
            return RedirectToAction("Index");
        }

        private int GetRandomFamerID(List<Farmer> farmers)
        {
            var random = new Random();
            return farmers.Skip(random.Next(0, farmers.Count - 1)).First().ID;
        }

        private IList<Feature> GetRandomFeatures(List<Feature> features)
        {
            var random = new Random();
            var featuresToReturn = new List<Feature>();
            
            featuresToReturn.Add(features.Skip(random.Next(0, features.Count - 1)).First());
            if (random.Next() % 2 == 0)
            {
                featuresToReturn.Add(features.Skip(random.Next(0, features.Count - 1)).First());
            }
            return featuresToReturn;
        }


    }
}
