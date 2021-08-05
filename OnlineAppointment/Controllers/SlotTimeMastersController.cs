using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineAppointment.Models;

namespace OnlineAppointment.Controllers
{
    public class SlotTimeMastersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SlotTimeMasters
        public ActionResult Index()
        {
            return View(db.SlotTimeMasters.ToList());
        }

        // GET: SlotTimeMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SlotTimeMaster slotTimeMaster = db.SlotTimeMasters.Find(id);
            if (slotTimeMaster == null)
            {
                return HttpNotFound();
            }
            return View(slotTimeMaster);
        }

        // GET: SlotTimeMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SlotTimeMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SlotDateTime")] SlotTimeMaster slotTimeMaster)
        {
            if (ModelState.IsValid)
            {
                db.SlotTimeMasters.Add(slotTimeMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(slotTimeMaster);
        }

        // GET: SlotTimeMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SlotTimeMaster slotTimeMaster = db.SlotTimeMasters.Find(id);
            if (slotTimeMaster == null)
            {
                return HttpNotFound();
            }
            return View(slotTimeMaster);
        }

        // POST: SlotTimeMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SlotDateTime")] SlotTimeMaster slotTimeMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(slotTimeMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(slotTimeMaster);
        }

        // GET: SlotTimeMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SlotTimeMaster slotTimeMaster = db.SlotTimeMasters.Find(id);
            if (slotTimeMaster == null)
            {
                return HttpNotFound();
            }
            return View(slotTimeMaster);
        }

        // POST: SlotTimeMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SlotTimeMaster slotTimeMaster = db.SlotTimeMasters.Find(id);
            db.SlotTimeMasters.Remove(slotTimeMaster);
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
