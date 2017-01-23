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

namespace NoAccounts.Controllers
{
    public class ByCuisineController : Controller
    {
        private RestaurantContext db = new RestaurantContext();

        // GET: ByCuisine
        public ActionResult Index()
        {

            //
            return View(db.RestaurantGrades.ToList().Where(grad => grad.Grade == "A" || grad.Grade == "B").GroupBy(ct => ct.CuisineType).Count());
        }

        // GET: ByCuisine/Details/5
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

        // GET: ByCuisine/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ByCuisine/Create
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

        // GET: ByCuisine/Edit/5
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

        // POST: ByCuisine/Edit/5
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

        // GET: ByCuisine/Delete/5
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

        // POST: ByCuisine/Delete/5
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
