using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NoAccounts.DataAccessLayer;
using NoAccounts.Models;
using PagedList;

namespace NoAccounts.Controllers
{
    public class RestaurantGradesController : Controller
    {
        private RestaurantContext db = new RestaurantContext();

        // GET: RestaurantGrades
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.GradeEarned = String.IsNullOrEmpty(sortOrder) ? "grade" : "";
            
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var restaurantname = from s in db.RestaurantGrades
                                 select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                restaurantname = restaurantname.Where(s => s.Dba.Contains(searchString));
            }
            switch(sortOrder)
            {
                case "name_desc":
                    restaurantname = restaurantname.OrderByDescending(s => s.Dba);
                    break;
                case "grade":
                    restaurantname = restaurantname.OrderByDescending(s => s.Grade);
                    break;
                default:
                    restaurantname = restaurantname.OrderBy(s => s.Dba);
                    break;
            }
            int pageSize = 25;
            int pageNumber = (page ?? 1);
            return View(db.RestaurantGrades.ToList().ToPagedList(pageNumber,pageSize));
        }

        // GET: RestaurantGrades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantGrade restaurantGrade = db.RestaurantGrades.Find(id);
            if (restaurantGrade == null)
            {
                return HttpNotFound();
            }
            return View(restaurantGrade);
        }

        // GET: RestaurantGrades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RestaurantGrades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RestaurantGradeID,Camis,Dba,Boro,Building,Street,ZipCode,Phone,CuisineType,InspectionDate,ViolationCode,Score,Grade")] RestaurantGrade restaurantGrade)
        {
            if (ModelState.IsValid)
            {
                db.RestaurantGrades.Add(restaurantGrade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurantGrade);
        }

        // GET: RestaurantGrades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantGrade restaurantGrade = db.RestaurantGrades.Find(id);
            if (restaurantGrade == null)
            {
                return HttpNotFound();
            }
            return View(restaurantGrade);
        }

        // POST: RestaurantGrades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RestaurantGradeID,Camis,Dba,Boro,Building,Street,ZipCode,Phone,CuisineType,InspectionDate,ViolationCode,Score,Grade")] RestaurantGrade restaurantGrade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurantGrade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurantGrade);
        }

        // GET: RestaurantGrades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantGrade restaurantGrade = db.RestaurantGrades.Find(id);
            if (restaurantGrade == null)
            {
                return HttpNotFound();
            }
            return View(restaurantGrade);
        }

        // POST: RestaurantGrades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RestaurantGrade restaurantGrade = db.RestaurantGrades.Find(id);
            db.RestaurantGrades.Remove(restaurantGrade);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
