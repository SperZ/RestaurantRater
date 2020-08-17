using Microsoft.Ajax.Utilities;
using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantRater.Controllers
{
    public class RestaurantController : Controller
    {
        private RestaurantDbContext _dbContext = new RestaurantDbContext();
        // GET: Restaurant/Index Method, this index method returns the view to UI
        public ActionResult Index()
        {
            return View(_dbContext.Restaurants.ToList());
        }

        //GET : Restaurant/Create    //get methods are implicit if a actionresult doesnt have a annotation the method is assumed to be a get method
        public ActionResult Create()
        {
            return View();
        }

        //POST: Restaurant/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Restaurants.Add(restaurant);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurant); // this doesnt kill the form just returns the model given back to the view so the user can correct their mistakes
        }
    }
}