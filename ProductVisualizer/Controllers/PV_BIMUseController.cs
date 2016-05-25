using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProductVisualizer.Models;

namespace ProductVisualizer.Controllers
{
    public class PV_BIMUseController : Controller
    {
        private ProductVisualizerEntities db = new ProductVisualizerEntities();

        // GET: PV_BIMUse
        public ActionResult Index()
        {
            return View(db.PV_BIMUse.ToList());
        }

        // GET: PV_BIMUse/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PV_BIMUse pV_BIMUse = db.PV_BIMUse.Find(id);
            if (pV_BIMUse == null)
            {
                return HttpNotFound();
            }
            return View(pV_BIMUse);
        }

        // GET: PV_BIMUse/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PV_BIMUse/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,BIMUsePage")] PV_BIMUse pV_BIMUse)
        {
            if (ModelState.IsValid)
            {
                db.PV_BIMUse.Add(pV_BIMUse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pV_BIMUse);
        }

        // GET: PV_BIMUse/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PV_BIMUse pV_BIMUse = db.PV_BIMUse.Find(id);
            if (pV_BIMUse == null)
            {
                return HttpNotFound();
            }
            return View(pV_BIMUse);
        }

        // POST: PV_BIMUse/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,BIMUsePage")] PV_BIMUse pV_BIMUse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pV_BIMUse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pV_BIMUse);
        }

        // GET: PV_BIMUse/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PV_BIMUse pV_BIMUse = db.PV_BIMUse.Find(id);
            if (pV_BIMUse == null)
            {
                return HttpNotFound();
            }
            return View(pV_BIMUse);
        }

        // POST: PV_BIMUse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PV_BIMUse pV_BIMUse = db.PV_BIMUse.Find(id);
            db.PV_BIMUse.Remove(pV_BIMUse);
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
