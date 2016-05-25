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
    public class PV_PhaseController : Controller
    {
        private ProductVisualizerEntities db = new ProductVisualizerEntities();

        // GET: PV_Phase
        public ActionResult Index()
        {
            return View(db.PV_Phase.ToList());
        }

        // GET: PV_Phase/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PV_Phase pV_Phase = db.PV_Phase.Find(id);
            if (pV_Phase == null)
            {
                return HttpNotFound();
            }
            return View(pV_Phase);
        }

        // GET: PV_Phase/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PV_Phase/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Category,Standard")] PV_Phase pV_Phase)
        {
            if (ModelState.IsValid)
            {
                db.PV_Phase.Add(pV_Phase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pV_Phase);
        }

        // GET: PV_Phase/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PV_Phase pV_Phase = db.PV_Phase.Find(id);
            if (pV_Phase == null)
            {
                return HttpNotFound();
            }
            return View(pV_Phase);
        }

        // POST: PV_Phase/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Category,Standard")] PV_Phase pV_Phase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pV_Phase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pV_Phase);
        }

        // GET: PV_Phase/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PV_Phase pV_Phase = db.PV_Phase.Find(id);
            if (pV_Phase == null)
            {
                return HttpNotFound();
            }
            return View(pV_Phase);
        }

        // POST: PV_Phase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PV_Phase pV_Phase = db.PV_Phase.Find(id);
            db.PV_Phase.Remove(pV_Phase);
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
