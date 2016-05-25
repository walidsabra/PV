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
    public class PV_GEOController : Controller
    {
        private ProductVisualizerEntities db = new ProductVisualizerEntities();

        // GET: PV_GEO
        public ActionResult Index()
        {
            return View(db.PV_GEO.ToList());
        }

        // GET: PV_GEO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PV_GEO pV_GEO = db.PV_GEO.Find(id);
            if (pV_GEO == null)
            {
                return HttpNotFound();
            }
            return View(pV_GEO);
        }

        // GET: PV_GEO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PV_GEO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Country,Location")] PV_GEO pV_GEO)
        {
            if (ModelState.IsValid)
            {
                db.PV_GEO.Add(pV_GEO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pV_GEO);
        }

        // GET: PV_GEO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PV_GEO pV_GEO = db.PV_GEO.Find(id);
            if (pV_GEO == null)
            {
                return HttpNotFound();
            }
            return View(pV_GEO);
        }

        // POST: PV_GEO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Country,Location")] PV_GEO pV_GEO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pV_GEO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pV_GEO);
        }

        // GET: PV_GEO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PV_GEO pV_GEO = db.PV_GEO.Find(id);
            if (pV_GEO == null)
            {
                return HttpNotFound();
            }
            return View(pV_GEO);
        }

        // POST: PV_GEO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PV_GEO pV_GEO = db.PV_GEO.Find(id);
            db.PV_GEO.Remove(pV_GEO);
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
