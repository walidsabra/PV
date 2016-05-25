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
    public class PV_LinkerController : Controller
    {
        private ProductVisualizerEntities db = new ProductVisualizerEntities();

        // GET: PV_Linker
        public ActionResult Index()
        {
            return View(db.PV_Linker.ToList());
        }

        // GET: PV_Linker/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PV_Linker pV_Linker = db.PV_Linker.Find(id);
            if (pV_Linker == null)
            {
                return HttpNotFound();
            }
            return View(pV_Linker);
        }

        // GET: PV_Linker/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PV_Linker/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SoftwareId,GEOId,IndustryId,PersonaId,PhaseId,BIMUseId")] PV_Linker pV_Linker)
        {
            if (ModelState.IsValid)
            {
                db.PV_Linker.Add(pV_Linker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pV_Linker);
        }

        // GET: PV_Linker/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PV_Linker pV_Linker = db.PV_Linker.Find(id);
            if (pV_Linker == null)
            {
                return HttpNotFound();
            }
            return View(pV_Linker);
        }

        // POST: PV_Linker/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SoftwareId,GEOId,IndustryId,PersonaId,PhaseId,BIMUseId")] PV_Linker pV_Linker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pV_Linker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pV_Linker);
        }

        // GET: PV_Linker/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PV_Linker pV_Linker = db.PV_Linker.Find(id);
            if (pV_Linker == null)
            {
                return HttpNotFound();
            }
            return View(pV_Linker);
        }

        // POST: PV_Linker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PV_Linker pV_Linker = db.PV_Linker.Find(id);
            db.PV_Linker.Remove(pV_Linker);
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
