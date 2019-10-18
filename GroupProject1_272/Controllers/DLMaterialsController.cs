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
    public class DLMaterialsController : Controller
    {
        private CollectorsEntities db = new CollectorsEntities();

        // GET: DLMaterials
        public ActionResult Index()
        {
            var dLMaterials = db.DLMaterials.Include(d => d.Donation_Line).Include(d => d.Material);
            return View(dLMaterials.ToList());
        }

        // GET: DLMaterials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DLMaterial dLMaterial = db.DLMaterials.Find(id);
            if (dLMaterial == null)
            {
                return HttpNotFound();
            }
            return View(dLMaterial);
        }

        // GET: DLMaterials/Create
        public ActionResult Create()
        {
            ViewBag.DL_ID = new SelectList(db.Donation_Line, "DL_ID", "DL_Description");
            ViewBag.Material_ID = new SelectList(db.Materials, "Material_ID", "Material_Description");
            return View();
        }

        // POST: DLMaterials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DLMaterial_ID,DLMaterial_Description,Condition,DL_ID,Material_ID")] DLMaterial dLMaterial)
        {
            if (ModelState.IsValid)
            {
                db.DLMaterials.Add(dLMaterial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DL_ID = new SelectList(db.Donation_Line, "DL_ID", "DL_Description", dLMaterial.DL_ID);
            ViewBag.Material_ID = new SelectList(db.Materials, "Material_ID", "Material_Description", dLMaterial.Material_ID);
            return View(dLMaterial);
        }

        // GET: DLMaterials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DLMaterial dLMaterial = db.DLMaterials.Find(id);
            if (dLMaterial == null)
            {
                return HttpNotFound();
            }
            ViewBag.DL_ID = new SelectList(db.Donation_Line, "DL_ID", "DL_Description", dLMaterial.DL_ID);
            ViewBag.Material_ID = new SelectList(db.Materials, "Material_ID", "Material_Description", dLMaterial.Material_ID);
            return View(dLMaterial);
        }

        // POST: DLMaterials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DLMaterial_ID,DLMaterial_Description,Condition,DL_ID,Material_ID")] DLMaterial dLMaterial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dLMaterial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DL_ID = new SelectList(db.Donation_Line, "DL_ID", "DL_Description", dLMaterial.DL_ID);
            ViewBag.Material_ID = new SelectList(db.Materials, "Material_ID", "Material_Description", dLMaterial.Material_ID);
            return View(dLMaterial);
        }

        // GET: DLMaterials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DLMaterial dLMaterial = db.DLMaterials.Find(id);
            if (dLMaterial == null)
            {
                return HttpNotFound();
            }
            return View(dLMaterial);
        }

        // POST: DLMaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DLMaterial dLMaterial = db.DLMaterials.Find(id);
            db.DLMaterials.Remove(dLMaterial);
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
