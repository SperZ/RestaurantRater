using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantRater.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Restaurant/Index Method, this index method returns the view to UI
        public ActionResult Index()
        {
            return View();
        }
    }
}