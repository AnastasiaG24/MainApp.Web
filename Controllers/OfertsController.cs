using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.Domain.Entities.Product;
// TEMPLATE, EXEMPLE OF HOW IT SHOULD BE
namespace MainApp.Web.Controllers
{
    public class OfertsController : Controller
    {
        private UserContext db = new UserContext();

        // GET: Oferts
        public ActionResult Index()
        {
            return View(db.Oferts.ToList());
        }

        // GET: Oferts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ofert ofert = db.Oferts.Find(id);
            if (ofert == null)
            {
                return HttpNotFound();
            }
            return View(ofert);
        }

        // GET: Oferts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Oferts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,StartDate,EndDate,Price,IsAllIn")] Ofert ofert)
        {
            if (ModelState.IsValid)
            {
                db.Oferts.Add(ofert);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ofert);
        }

        // GET: Oferts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ofert ofert = db.Oferts.Find(id);
            if (ofert == null)
            {
                return HttpNotFound();
            }
            return View(ofert);
        }

        // POST: Oferts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,StartDate,EndDate,Price,IsAllIn")] Ofert ofert)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ofert).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ofert);
        }

        // GET: Oferts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ofert ofert = db.Oferts.Find(id);
            if (ofert == null)
            {
                return HttpNotFound();
            }
            return View(ofert);
        }

        // POST: Oferts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ofert ofert = db.Oferts.Find(id);
            db.Oferts.Remove(ofert);
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
