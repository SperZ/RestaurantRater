using Microsoft.Ajax.Utilities;
using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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

        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Restaurant restaurant = _dbContext.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(int id)
        {
            Restaurant restaurant = _dbContext.Restaurants.Find(id);
            _dbContext.Restaurants.Remove(restaurant);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Restaurant/Edit/{id}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = _dbContext.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Entry(restaurant).State = EntityState.Modified; //the entry will query the database and see if there is a model that matches up with the model passed in through the parameters
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurant); // this will return the edit view, it is exactly the same as what the user entered so they can make changes that are appropiate with out losing previously entered data that is valid.
        }

        //Get: Restaurant/Details{id}

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = _dbContext.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }
    }
}