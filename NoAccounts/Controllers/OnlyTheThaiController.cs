using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using NoAccounts.Models;
using NoAccounts.DataAccessLayer;


namespace NoAccounts.Controllers
{
    public class OnlyTheThaiController : Controller
    {
        private RestaurantContext db = new RestaurantContext();
        // GET: OnlyTheThai
        public ActionResult Index()
        {
            return View(db.RestaurantGrades.ToList().Where(cuisine => cuisine.CuisineType == "Thai"));
        }

    }
}