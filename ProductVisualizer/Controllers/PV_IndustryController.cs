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
    public class PV_IndustryController : Controller
    {
        private ProductVisualizerEntities db = new ProductVisualizerEntities();

        // GET: PV_Industry
        public ActionResult Index()
        {
            return View(db.PV_Industry.ToList());
        }

        // GET: PV_Industry/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PV_Industry pV_Industry = db.PV_Industry.Find(id);
            if (pV_Industry == null)
            {
                return HttpNotFound();
            }
            return View(pV_Industry);
        }

        // GET: PV_Industry/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PV_Industry/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] PV_Industry pV_Industry)
        {
            if (ModelState.IsValid)
            {
                db.PV_Industry.Add(pV_Industry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pV_Industry);
        }

        // GET: PV_Industry/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PV_Industry pV_Industry = db.PV_Industry.Find(id);
            if (pV_Industry == null)
            {
                return HttpNotFound();
            }
            return View(pV_Industry);
        }

        // POST: PV_Industry/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] PV_Industry pV_Industry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pV_Industry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pV_Industry);
        }

        // GET: PV_Industry/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PV_Industry pV_Industry = db.PV_Industry.Find(id);
            if (pV_Industry == null)
            {
                return HttpNotFound();
            }
            return View(pV_Industry);
        }

        // POST: PV_Industry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PV_Industry pV_Industry = db.PV_Industry.Find(id);
            db.PV_Industry.Remove(pV_Industry);
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
