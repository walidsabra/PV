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
    public class PV_PersonaController : Controller
    {
        private ProductVisualizerEntities db = new ProductVisualizerEntities();

        // GET: PV_Persona
        public ActionResult Index()
        {
            return View(db.PV_Persona.ToList());
        }

        // GET: PV_Persona/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PV_Persona pV_Persona = db.PV_Persona.Find(id);
            if (pV_Persona == null)
            {
                return HttpNotFound();
            }
            return View(pV_Persona);
        }

        // GET: PV_Persona/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PV_Persona/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Type")] PV_Persona pV_Persona)
        {
            if (ModelState.IsValid)
            {
                db.PV_Persona.Add(pV_Persona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pV_Persona);
        }

        // GET: PV_Persona/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PV_Persona pV_Persona = db.PV_Persona.Find(id);
            if (pV_Persona == null)
            {
                return HttpNotFound();
            }
            return View(pV_Persona);
        }

        // POST: PV_Persona/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Type")] PV_Persona pV_Persona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pV_Persona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pV_Persona);
        }

        // GET: PV_Persona/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PV_Persona pV_Persona = db.PV_Persona.Find(id);
            if (pV_Persona == null)
            {
                return HttpNotFound();
            }
            return View(pV_Persona);
        }

        // POST: PV_Persona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PV_Persona pV_Persona = db.PV_Persona.Find(id);
            db.PV_Persona.Remove(pV_Persona);
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
