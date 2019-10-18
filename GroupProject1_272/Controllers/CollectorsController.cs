using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GroupProject1_272.Models;

namespace GroupProject1_272.Views
{
    public class CollectorsController : Controller
    {
        private CollectorsEntities db = new CollectorsEntities();

        // GET: Collectors
        public ActionResult Index()
        {
            return View(db.Collectors.ToList());
        }

        // GET: Collectors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collector collector = db.Collectors.Find(id);
            if (collector == null)
            {
                return HttpNotFound();
            }
            return View(collector);
        }

        // GET: Collectors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Collectors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Collector_ID,Collector_Name,Collector_Surname")] Collector collector)
        {
            if (ModelState.IsValid)
            {
                db.Collectors.Add(collector);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(collector);
        }

        // GET: Collectors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collector collector = db.Collectors.Find(id);
            if (collector == null)
            {
                return HttpNotFound();
            }
            return View(collector);
        }

        // POST: Collectors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Collector_ID,Collector_Name,Collector_Surname")] Collector collector)
        {
            if (ModelState.IsValid)
            {
                db.Entry(collector).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(collector);
        }

        // GET: Collectors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collector collector = db.Collectors.Find(id);
            if (collector == null)
            {
                return HttpNotFound();
            }
            return View(collector);
        }

        // POST: Collectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Collector collector = db.Collectors.Find(id);
            db.Collectors.Remove(collector);
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
