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
    public class ProcessMastersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProcessMasters
        public ActionResult Index()
        {
            var processMasters = db.ProcessMasters.Include(p => p.AppointmentMaster);
            return View(processMasters.ToList());
        }

        // GET: ProcessMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProcessMaster processMaster = db.ProcessMasters.Find(id);
            if (processMaster == null)
            {
                return HttpNotFound();
            }
            return View(processMaster);
        }

        // GET: ProcessMasters/Create
        public ActionResult Create()
        {
            ViewBag.AppointmentMasterID = new SelectList(db.AppointmentMasters, "ID", "ID");
            return View();
        }

        // POST: ProcessMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AppointmentMasterID,ProcessDate,Remarks")] ProcessMaster processMaster)
        {
            if (ModelState.IsValid)
            {
                db.ProcessMasters.Add(processMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AppointmentMasterID = new SelectList(db.AppointmentMasters, "ID", "ID", processMaster.AppointmentMasterID);
            return View(processMaster);
        }

        // GET: ProcessMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProcessMaster processMaster = db.ProcessMasters.Find(id);
            if (processMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.AppointmentMasterID = new SelectList(db.AppointmentMasters, "ID", "ID", processMaster.AppointmentMasterID);
            return View(processMaster);
        }

        // POST: ProcessMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AppointmentMasterID,ProcessDate,Remarks")] ProcessMaster processMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(processMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AppointmentMasterID = new SelectList(db.AppointmentMasters, "ID", "ID", processMaster.AppointmentMasterID);
            return View(processMaster);
        }

        // GET: ProcessMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProcessMaster processMaster = db.ProcessMasters.Find(id);
            if (processMaster == null)
            {
                return HttpNotFound();
            }
            return View(processMaster);
        }

        // POST: ProcessMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProcessMaster processMaster = db.ProcessMasters.Find(id);
            db.ProcessMasters.Remove(processMaster);
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
