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
    public class Walk_InController : Controller
    {
        private CollectorsEntities db = new CollectorsEntities();

        // GET: Walk_In
        public ActionResult Index()
        {
            var walk_In = db.Walk_In.Include(w => w.Collector).Include(w => w.Employee);
            return View(walk_In.ToList());
        }

        // GET: Walk_In/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Walk_In walk_In = db.Walk_In.Find(id);
            if (walk_In == null)
            {
                return HttpNotFound();
            }
            return View(walk_In);
        }

        // GET: Walk_In/Create
        public ActionResult Create()
        {
            ViewBag.Collector_ID = new SelectList(db.Collectors, "Collector_ID", "Collector_Name");
            ViewBag.Employee_ID = new SelectList(db.Employees, "Employee_ID", "Employee_Name");
            return View();
        }

        // POST: Walk_In/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WalkIn_ID,Date,Material_Brought,Remuneration,Collector_ID,Employee_ID")] Walk_In walk_In)
        {
            if (ModelState.IsValid)
            {
                db.Walk_In.Add(walk_In);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Collector_ID = new SelectList(db.Collectors, "Collector_ID", "Collector_Name", walk_In.Collector_ID);
            ViewBag.Employee_ID = new SelectList(db.Employees, "Employee_ID", "Employee_Name", walk_In.Employee_ID);
            return View(walk_In);
        }

        // GET: Walk_In/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Walk_In walk_In = db.Walk_In.Find(id);
            if (walk_In == null)
            {
                return HttpNotFound();
            }
            ViewBag.Collector_ID = new SelectList(db.Collectors, "Collector_ID", "Collector_Name", walk_In.Collector_ID);
            ViewBag.Employee_ID = new SelectList(db.Employees, "Employee_ID", "Employee_Name", walk_In.Employee_ID);
            return View(walk_In);
        }

        // POST: Walk_In/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WalkIn_ID,Date,Material_Brought,Remuneration,Collector_ID,Employee_ID")] Walk_In walk_In)
        {
            if (ModelState.IsValid)
            {
                db.Entry(walk_In).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Collector_ID = new SelectList(db.Collectors, "Collector_ID", "Collector_Name", walk_In.Collector_ID);
            ViewBag.Employee_ID = new SelectList(db.Employees, "Employee_ID", "Employee_Name", walk_In.Employee_ID);
            return View(walk_In);
        }

        // GET: Walk_In/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Walk_In walk_In = db.Walk_In.Find(id);
            if (walk_In == null)
            {
                return HttpNotFound();
            }
            return View(walk_In);
        }

        // POST: Walk_In/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Walk_In walk_In = db.Walk_In.Find(id);
            db.Walk_In.Remove(walk_In);
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
