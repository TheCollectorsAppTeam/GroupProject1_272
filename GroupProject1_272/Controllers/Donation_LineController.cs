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
    public class Donation_LineController : Controller
    {
        private CollectorsEntities db = new CollectorsEntities();

        // GET: Donation_Line
        public ActionResult Index()
        {
            var donation_Line = db.Donation_Line.Include(d => d.Donation).Include(d => d.Payment);
            return View(donation_Line.ToList());
        }

        // GET: Donation_Line/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation_Line donation_Line = db.Donation_Line.Find(id);
            if (donation_Line == null)
            {
                return HttpNotFound();
            }
            return View(donation_Line);
        }

        // GET: Donation_Line/Create
        public ActionResult Create()
        {
            ViewBag.Donation_ID = new SelectList(db.Donations, "Donation_ID", "Donation_ID");
            ViewBag.Payment_ID = new SelectList(db.Payments, "Payment_ID", "Details");
            return View();
        }

        // POST: Donation_Line/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DL_ID,DL_Description,Donation_ID,Payment_ID")] Donation_Line donation_Line)
        {
            if (ModelState.IsValid)
            {
                db.Donation_Line.Add(donation_Line);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Donation_ID = new SelectList(db.Donations, "Donation_ID", "Donation_ID", donation_Line.Donation_ID);
            ViewBag.Payment_ID = new SelectList(db.Payments, "Payment_ID", "Details", donation_Line.Payment_ID);
            return View(donation_Line);
        }

        // GET: Donation_Line/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation_Line donation_Line = db.Donation_Line.Find(id);
            if (donation_Line == null)
            {
                return HttpNotFound();
            }
            ViewBag.Donation_ID = new SelectList(db.Donations, "Donation_ID", "Donation_ID", donation_Line.Donation_ID);
            ViewBag.Payment_ID = new SelectList(db.Payments, "Payment_ID", "Details", donation_Line.Payment_ID);
            return View(donation_Line);
        }

        // POST: Donation_Line/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DL_ID,DL_Description,Donation_ID,Payment_ID")] Donation_Line donation_Line)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donation_Line).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Donation_ID = new SelectList(db.Donations, "Donation_ID", "Donation_ID", donation_Line.Donation_ID);
            ViewBag.Payment_ID = new SelectList(db.Payments, "Payment_ID", "Details", donation_Line.Payment_ID);
            return View(donation_Line);
        }

        // GET: Donation_Line/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation_Line donation_Line = db.Donation_Line.Find(id);
            if (donation_Line == null)
            {
                return HttpNotFound();
            }
            return View(donation_Line);
        }

        // POST: Donation_Line/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Donation_Line donation_Line = db.Donation_Line.Find(id);
            db.Donation_Line.Remove(donation_Line);
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
