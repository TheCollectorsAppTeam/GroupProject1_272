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
    public class WalkIn_MaterialController : Controller
    {
        private CollectorsEntities db = new CollectorsEntities();

        // GET: WalkIn_Material
        public ActionResult Index()
        {
            var walkIn_Material = db.WalkIn_Material.Include(w => w.Collector).Include(w => w.Employee).Include(w => w.Material).Include(w => w.Walk_In);
            return View(walkIn_Material.ToList());
        }

        // GET: WalkIn_Material/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WalkIn_Material walkIn_Material = db.WalkIn_Material.Find(id);
            if (walkIn_Material == null)
            {
                return HttpNotFound();
            }
            return View(walkIn_Material);
        }

        // GET: WalkIn_Material/Create
        public ActionResult Create()
        {
            ViewBag.Collector_ID = new SelectList(db.Collectors, "Collector_ID", "Collector_Name");
            ViewBag.Employee_ID = new SelectList(db.Employees, "Employee_ID", "Employee_Name");
            ViewBag.Material_ID = new SelectList(db.Materials, "Material_ID", "Material_Description");
            ViewBag.WalkIn_ID = new SelectList(db.Walk_In, "WalkIn_ID", "Material_Brought");
            return View();
        }

        // POST: WalkIn_Material/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Material_ID,Collector_ID,Employee_ID,Quantity,WalkIn_ID")] WalkIn_Material walkIn_Material)
        {
            if (ModelState.IsValid)
            {
                db.WalkIn_Material.Add(walkIn_Material);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Collector_ID = new SelectList(db.Collectors, "Collector_ID", "Collector_Name", walkIn_Material.Collector_ID);
            ViewBag.Employee_ID = new SelectList(db.Employees, "Employee_ID", "Employee_Name", walkIn_Material.Employee_ID);
            ViewBag.Material_ID = new SelectList(db.Materials, "Material_ID", "Material_Description", walkIn_Material.Material_ID);
            ViewBag.WalkIn_ID = new SelectList(db.Walk_In, "WalkIn_ID", "Material_Brought", walkIn_Material.WalkIn_ID);
            return View(walkIn_Material);
        }

        // GET: WalkIn_Material/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WalkIn_Material walkIn_Material = db.WalkIn_Material.Find(id);
            if (walkIn_Material == null)
            {
                return HttpNotFound();
            }
            ViewBag.Collector_ID = new SelectList(db.Collectors, "Collector_ID", "Collector_Name", walkIn_Material.Collector_ID);
            ViewBag.Employee_ID = new SelectList(db.Employees, "Employee_ID", "Employee_Name", walkIn_Material.Employee_ID);
            ViewBag.Material_ID = new SelectList(db.Materials, "Material_ID", "Material_Description", walkIn_Material.Material_ID);
            ViewBag.WalkIn_ID = new SelectList(db.Walk_In, "WalkIn_ID", "Material_Brought", walkIn_Material.WalkIn_ID);
            return View(walkIn_Material);
        }

        // POST: WalkIn_Material/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Material_ID,Collector_ID,Employee_ID,Quantity,WalkIn_ID")] WalkIn_Material walkIn_Material)
        {
            if (ModelState.IsValid)
            {
                db.Entry(walkIn_Material).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Collector_ID = new SelectList(db.Collectors, "Collector_ID", "Collector_Name", walkIn_Material.Collector_ID);
            ViewBag.Employee_ID = new SelectList(db.Employees, "Employee_ID", "Employee_Name", walkIn_Material.Employee_ID);
            ViewBag.Material_ID = new SelectList(db.Materials, "Material_ID", "Material_Description", walkIn_Material.Material_ID);
            ViewBag.WalkIn_ID = new SelectList(db.Walk_In, "WalkIn_ID", "Material_Brought", walkIn_Material.WalkIn_ID);
            return View(walkIn_Material);
        }

        // GET: WalkIn_Material/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WalkIn_Material walkIn_Material = db.WalkIn_Material.Find(id);
            if (walkIn_Material == null)
            {
                return HttpNotFound();
            }
            return View(walkIn_Material);
        }

        // POST: WalkIn_Material/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WalkIn_Material walkIn_Material = db.WalkIn_Material.Find(id);
            db.WalkIn_Material.Remove(walkIn_Material);
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
