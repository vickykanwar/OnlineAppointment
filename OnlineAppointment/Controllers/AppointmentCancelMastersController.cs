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
    public class AppointmentCancelMastersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AppointmentCancelMasters
        public ActionResult Index()
        {
            var appointmentCancelMasters = db.AppointmentCancelMasters.Include(a => a.AppointmentMaster);
            return View(appointmentCancelMasters.ToList());
        }

        // GET: AppointmentCancelMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointmentCancelMaster appointmentCancelMaster = db.AppointmentCancelMasters.Find(id);
            if (appointmentCancelMaster == null)
            {
                return HttpNotFound();
            }
            return View(appointmentCancelMaster);
        }

        // GET: AppointmentCancelMasters/Create
        public ActionResult Create()
        {
            ViewBag.AppointmentMasterID = new SelectList(db.AppointmentMasters, "ID", "ID");
            return View();
        }

        // POST: AppointmentCancelMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AppointmentMasterID,CancelDate,Reason")] AppointmentCancelMaster appointmentCancelMaster)
        {
            if (ModelState.IsValid)
            {
                db.AppointmentCancelMasters.Add(appointmentCancelMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AppointmentMasterID = new SelectList(db.AppointmentMasters, "ID", "ID", appointmentCancelMaster.AppointmentMasterID);
            return View(appointmentCancelMaster);
        }

        // GET: AppointmentCancelMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointmentCancelMaster appointmentCancelMaster = db.AppointmentCancelMasters.Find(id);
            if (appointmentCancelMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.AppointmentMasterID = new SelectList(db.AppointmentMasters, "ID", "ID", appointmentCancelMaster.AppointmentMasterID);
            return View(appointmentCancelMaster);
        }

        // POST: AppointmentCancelMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AppointmentMasterID,CancelDate,Reason")] AppointmentCancelMaster appointmentCancelMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointmentCancelMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AppointmentMasterID = new SelectList(db.AppointmentMasters, "ID", "ID", appointmentCancelMaster.AppointmentMasterID);
            return View(appointmentCancelMaster);
        }

        // GET: AppointmentCancelMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointmentCancelMaster appointmentCancelMaster = db.AppointmentCancelMasters.Find(id);
            if (appointmentCancelMaster == null)
            {
                return HttpNotFound();
            }
            return View(appointmentCancelMaster);
        }

        // POST: AppointmentCancelMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AppointmentCancelMaster appointmentCancelMaster = db.AppointmentCancelMasters.Find(id);
            db.AppointmentCancelMasters.Remove(appointmentCancelMaster);
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
