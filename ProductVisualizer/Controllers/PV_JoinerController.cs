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
    public class PV_JoinerController : Controller
    {
        private ProductVisualizerEntities db = new ProductVisualizerEntities();

        // GET: PV_Joiner
        public ActionResult Index()
        {
            return View(db.PV_Joiner.ToList());
        }

        // GET: PV_Joiner/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PV_Joiner pV_Joiner = db.PV_Joiner.Find(id);
            if (pV_Joiner == null)
            {
                return HttpNotFound();
            }
            return View(pV_Joiner);
        }

        // GET: PV_Joiner/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PV_Joiner/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id1,Id2,Tables,ID")] PV_Joiner pV_Joiner)
        {
            if (ModelState.IsValid)
            {
                db.PV_Joiner.Add(pV_Joiner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pV_Joiner);
        }

        // GET: PV_Joiner/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PV_Joiner pV_Joiner = db.PV_Joiner.Find(id);
            if (pV_Joiner == null)
            {
                return HttpNotFound();
            }
            return View(pV_Joiner);
        }

        // POST: PV_Joiner/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id1,Id2,Tables,ID")] PV_Joiner pV_Joiner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pV_Joiner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pV_Joiner);
        }

        // GET: PV_Joiner/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PV_Joiner pV_Joiner = db.PV_Joiner.Find(id);
            if (pV_Joiner == null)
            {
                return HttpNotFound();
            }
            return View(pV_Joiner);
        }

        // POST: PV_Joiner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PV_Joiner pV_Joiner = db.PV_Joiner.Find(id);
            db.PV_Joiner.Remove(pV_Joiner);
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
