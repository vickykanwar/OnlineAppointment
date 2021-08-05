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
    [Authorize]
    public class ServiceMastersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ServiceMasters
        public ActionResult Index()
        {
            return View(db.ServiceMasters.ToList());
        }

        // GET: ServiceMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceMaster serviceMaster = db.ServiceMasters.Find(id);
            if (serviceMaster == null)
            {
                return HttpNotFound();
            }
            return View(serviceMaster);
        }

        // GET: ServiceMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiceMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ServiceName")] ServiceMaster serviceMaster)
        {
            if (ModelState.IsValid)
            {
                db.ServiceMasters.Add(serviceMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(serviceMaster);
        }

        // GET: ServiceMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceMaster serviceMaster = db.ServiceMasters.Find(id);
            if (serviceMaster == null)
            {
                return HttpNotFound();
            }
            return View(serviceMaster);
        }

        // POST: ServiceMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ServiceName")] ServiceMaster serviceMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serviceMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(serviceMaster);
        }

        // GET: ServiceMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceMaster serviceMaster = db.ServiceMasters.Find(id);
            if (serviceMaster == null)
            {
                return HttpNotFound();
            }
            return View(serviceMaster);
        }

        // POST: ServiceMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceMaster serviceMaster = db.ServiceMasters.Find(id);
            db.ServiceMasters.Remove(serviceMaster);
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
