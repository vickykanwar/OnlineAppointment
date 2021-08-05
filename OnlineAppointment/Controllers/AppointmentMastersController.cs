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
    public class AppointmentMastersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AppointmentMasters
        public ActionResult Index()
        {
            var appointmentMasters = db.AppointmentMasters.Include(a => a.CustomerMaster).Include(a => a.ServiceMaster).Include(a => a.SlotTimeMaster);
            return View(appointmentMasters.ToList());
        }

        // GET: AppointmentMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointmentMaster appointmentMaster = db.AppointmentMasters.Find(id);
            if (appointmentMaster == null)
            {
                return HttpNotFound();
            }
            return View(appointmentMaster);
        }

        // GET: AppointmentMasters/Create
        public ActionResult Create()
        {
            ViewBag.CustomerMasterID = new SelectList(db.CustomerMasters, "ID", "Name");
            ViewBag.ServiceMasterID = new SelectList(db.ServiceMasters, "ID", "ServiceName");
            ViewBag.SlotTimeMasterID = new SelectList(db.SlotTimeMasters, "ID", "ID");
            return View();
        }

        // POST: AppointmentMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ServiceMasterID,CustomerMasterID,SlotTimeMasterID,Date")] AppointmentMaster appointmentMaster)
        {
            if (ModelState.IsValid)
            {
                db.AppointmentMasters.Add(appointmentMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerMasterID = new SelectList(db.CustomerMasters, "ID", "Name", appointmentMaster.CustomerMasterID);
            ViewBag.ServiceMasterID = new SelectList(db.ServiceMasters, "ID", "ServiceName", appointmentMaster.ServiceMasterID);
            ViewBag.SlotTimeMasterID = new SelectList(db.SlotTimeMasters, "ID", "ID", appointmentMaster.SlotTimeMasterID);
            return View(appointmentMaster);
        }

        // GET: AppointmentMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointmentMaster appointmentMaster = db.AppointmentMasters.Find(id);
            if (appointmentMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerMasterID = new SelectList(db.CustomerMasters, "ID", "Name", appointmentMaster.CustomerMasterID);
            ViewBag.ServiceMasterID = new SelectList(db.ServiceMasters, "ID", "ServiceName", appointmentMaster.ServiceMasterID);
            ViewBag.SlotTimeMasterID = new SelectList(db.SlotTimeMasters, "ID", "ID", appointmentMaster.SlotTimeMasterID);
            return View(appointmentMaster);
        }

        // POST: AppointmentMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ServiceMasterID,CustomerMasterID,SlotTimeMasterID,Date")] AppointmentMaster appointmentMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointmentMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerMasterID = new SelectList(db.CustomerMasters, "ID", "Name", appointmentMaster.CustomerMasterID);
            ViewBag.ServiceMasterID = new SelectList(db.ServiceMasters, "ID", "ServiceName", appointmentMaster.ServiceMasterID);
            ViewBag.SlotTimeMasterID = new SelectList(db.SlotTimeMasters, "ID", "ID", appointmentMaster.SlotTimeMasterID);
            return View(appointmentMaster);
        }

        // GET: AppointmentMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointmentMaster appointmentMaster = db.AppointmentMasters.Find(id);
            if (appointmentMaster == null)
            {
                return HttpNotFound();
            }
            return View(appointmentMaster);
        }

        // POST: AppointmentMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AppointmentMaster appointmentMaster = db.AppointmentMasters.Find(id);
            db.AppointmentMasters.Remove(appointmentMaster);
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
