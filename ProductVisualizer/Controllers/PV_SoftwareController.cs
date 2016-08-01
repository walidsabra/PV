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
    public class PV_SoftwareController : Controller
    {
        private ProductVisualizerEntities db = new ProductVisualizerEntities();

        // GET: PV_Software
        public ActionResult Index()
        {
            return View(db.PV_Software.ToList());
        }

        //// GET: PV_Software
        //public ActionResult Matrix2(string c1, string c2, string ProjType)
        //{
        //    BindForLinking();
        //    //c1 Phase | c2 Persona
        //    IQueryable<AllDetail> lstProdcut;
        //    if (string.IsNullOrEmpty(ProjType))
        //        lstProdcut = db.AllDetails.AsQueryable();
        //    else
        //        lstProdcut = db.AllDetails.Where(ex => ex.Industry.Contains(ProjType)).AsQueryable();

        //    if (!string.IsNullOrEmpty(c1))
        //        lstProdcut = lstProdcut.Where(ex => ex.Phase.Contains(c1)).AsQueryable();

        //    if (!string.IsNullOrEmpty(c2))
        //        lstProdcut = lstProdcut.Where(ex => ex.Persona.Contains(c2)).AsQueryable();



        //    return Json(lstProdcut.ToList(), JsonRequestBehavior.AllowGet);
        //}

        // GET: PV_Software
        public ActionResult Cell(string c1, string c2)
        {
            string ProjType;
            //BindForLinking();


                if (Session["SelectedProjectType"] != null)
                {
                    ProjType = Session["SelectedProjectType"].ToString();
                }
            else
                 ProjType = string.Empty;

            //c1 Phase | c2 Persona
            IQueryable<AllDetail> lstProdcut;
            if (string.IsNullOrEmpty(ProjType))
                lstProdcut = db.AllDetails.AsQueryable();
            else
                lstProdcut = db.AllDetails.Where(ex => ex.Industry.Contains(ProjType)).AsQueryable();

            if (!string.IsNullOrEmpty(c1))
                lstProdcut = lstProdcut.Where(ex => ex.Phase.Contains(c1)).AsQueryable();

            if (!string.IsNullOrEmpty(c2))
                lstProdcut = lstProdcut.Where(ex => ex.Persona.Contains(c2)).AsQueryable();

            if (lstProdcut.Count() == 0)
            {
                return null;
            }

            return View(lstProdcut.ToList());
        }

        // GET: PV_Software
        public ActionResult Matrix(string ProjType)
        {
            BindForLinking(ProjType,"","","","");
            BindForMatrix(ProjType, "", "", "", "");

            if (ProjType == null)
            {
                if (Session["SelectedProjectType"] != null)
                {
                    ProjType = Session["SelectedProjectType"].ToString();
                }
            }

            else
                Session["SelectedProjectType"] = ProjType;

            //c1 Phase | c2 Persona
            IQueryable<AllDetail> lstProdcut;
            if (string.IsNullOrEmpty(ProjType))
                lstProdcut = db.AllDetails.AsQueryable();
            else
                lstProdcut = db.AllDetails.Where(ex => ex.Industry.Contains(ProjType)).AsQueryable();

            //if (!string.IsNullOrEmpty(c1))
            //    lstProdcut = lstProdcut.Where(ex => ex.Phase.Contains(c1)).AsQueryable();

            //if (!string.IsNullOrEmpty(c2))
            //    lstProdcut = lstProdcut.Where(ex => ex.Persona.Contains(c2)).AsQueryable();



            return View(lstProdcut.ToList());
        }

        // GET: PV_Software
        public ActionResult Filter(string SearchValue, string ProjType, string Phase, string BIMUse, string Persona, string GEO)
        {
        




            BindForLinking(ProjType, GEO,Phase,Persona,BIMUse);
            IQueryable<AllDetail> lstProdcut;
            if (string.IsNullOrEmpty(SearchValue))
                lstProdcut = db.AllDetails.AsQueryable();
            else

                lstProdcut = db.AllDetails.Where(ex => ex.GEO.Contains(SearchValue) || ex.Name.Contains(SearchValue) || ex.Persona.Contains(SearchValue) || ex.Phase.Contains(SearchValue) || ex.Industry.Contains(SearchValue) || ex.BIMUse.Contains(SearchValue)).AsQueryable();

            if (!string.IsNullOrEmpty(ProjType))
                lstProdcut = lstProdcut.Where(ex => ex.Industry.Contains(ProjType)).AsQueryable();
                //lstProdcut = db.AllDetails.Where(ex => ex.GEO.Contains(criteria) && ex.Industry.Contains(ProjType) ).ToList();

            if (!string.IsNullOrEmpty(Phase))
                lstProdcut = lstProdcut.Where(ex => ex.Phase.Contains(Phase)).AsQueryable();

            if (!string.IsNullOrEmpty(BIMUse))
                lstProdcut = lstProdcut.Where(ex => ex.BIMUse.Contains(BIMUse)).AsQueryable();

            if (!string.IsNullOrEmpty(Persona))
                lstProdcut = lstProdcut.Where(ex => ex.Persona.Contains(Persona)).AsQueryable();

            if (!string.IsNullOrEmpty(GEO))
                lstProdcut = lstProdcut.Where(ex => ex.GEO.Contains(GEO)).AsQueryable();

            return View(lstProdcut.ToList());

        }

        // GET: PV_Software/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PV_Software pV_Software = db.PV_Software.Find(id);
            if (pV_Software == null)
            {
                return HttpNotFound();
            }
            return View(pV_Software);
        }

        // GET: PV_Software/Link
        public ActionResult Link()
        {
            BindForLinker();

            return View();
        }

        // POST: PV_Software/Link
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Link(string Software , string GEO, string Industry, string Phase, string Persona, string BIMUse)
        {
            if (ModelState.IsValid)
            {
                PV_Linker LinkerItem = new PV_Linker();
                LinkerItem.SoftwareId = int.Parse(Software);


                if (string.IsNullOrEmpty(GEO))
                    LinkerItem.GEOId = null;
                else
                    LinkerItem.GEOId = int.Parse(GEO);

                if (string.IsNullOrEmpty(Industry))
                    LinkerItem.IndustryId = null;
                else
                    LinkerItem.IndustryId = int.Parse(Industry);

                if (string.IsNullOrEmpty(Persona))
                    LinkerItem.PersonaId = null;
                else
                    LinkerItem.PersonaId = int.Parse(Persona);

                if (string.IsNullOrEmpty(Phase))
                    LinkerItem.PhaseId = null;
                else
                    LinkerItem.PhaseId = int.Parse(Phase);

                if (string.IsNullOrEmpty(BIMUse))
                    LinkerItem.BIMUseId = null;
                else
                    LinkerItem.BIMUseId = int.Parse(BIMUse);


                db.PV_Linker.Add(LinkerItem);
                db.SaveChanges();

                return RedirectToAction("Link");
            }

            return View();
        }

        // GET: PV_Software/Create
        public ActionResult Create()
        {
            BindForLinker();
            return View();
        }


        // POST: PV_Software/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Features,Image,ProductPage,TrainingCourses,Version,Cost,Language")] PV_Software pV_Software, string GEO, string Industry)
        {
            if (ModelState.IsValid)
            {
                db.PV_Software.Add(pV_Software);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pV_Software);
        }

        // GET: PV_Software/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PV_Software pV_Software = db.PV_Software.Find(id);
            if (pV_Software == null)
            {
                return HttpNotFound();
            }
            return View(pV_Software);
        }

        // POST: PV_Software/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Features,Image,ProductPage,TrainingCourses,Version,Cost,Language")] PV_Software pV_Software)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pV_Software).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pV_Software);
        }

        // GET: PV_Software/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PV_Software pV_Software = db.PV_Software.Find(id);
            if (pV_Software == null)
            {
                return HttpNotFound();
            }
            return View(pV_Software);
        }

        // POST: PV_Software/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PV_Software pV_Software = db.PV_Software.Find(id);
            db.PV_Software.Remove(pV_Software);
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

        private void BindForLinking(string ProjType, string GEO, string Phase, string Persona, string BIMUse)
        {
            ViewBag.Software = new SelectList(db.PV_Software.ToList(), "Id", "Name");
            ViewBag.GEO = new SelectList(db.PV_GEO.ToList(), "Name", "Name", GEO);
            ViewBag.Industry = new SelectList(db.PV_Industry.ToList(), "Name", "Name", ProjType);
            ViewBag.Phase = new SelectList(db.PV_Phase.ToList(), "Name", "Name", Phase);
            ViewBag.Persona = new SelectList(db.PV_Persona.ToList(), "Name", "Name", Persona);
            ViewBag.BIMUse = new SelectList(db.PV_BIMUse.ToList(), "Name", "Name", BIMUse);
        }

        private void BindForMatrix(string ProjType, string GEO, string Phase, string Persona, string BIMUse)
        {
            ViewBag.LinkedSoftware = new SelectList(db.AllDetails.Select(x=>x.Id).Distinct().ToList());
            ViewBag.LinkedGEO = new SelectList(db.AllDetails.Select(x => x.GEO).Distinct().ToList());
            ViewBag.LinkedIndustry = new SelectList(db.AllDetails.Select(x=>x.Industry).Distinct().ToList());
            ViewBag.LinkedPhase = new SelectList(db.AllDetails.Select(x => x.Phase).Distinct().ToList());
            ViewBag.LinkedPersona = new SelectList(db.AllDetails.Select(x => x.Persona).Distinct().ToList());
            ViewBag.LinkedBIMUse = new SelectList(db.AllDetails.Select(x => x.BIMUse).Distinct().ToList());
        }

        private void BindForLinker()
        {
            ViewBag.Software = new SelectList(db.PV_Software.ToList(), "Id", "Name");
            ViewBag.GEO = new SelectList(db.PV_GEO.ToList(), "Id", "Name");
            ViewBag.Industry = new SelectList(db.PV_Industry.ToList(), "Id", "Name");
            ViewBag.Phase = new SelectList(db.PV_Phase.ToList(), "Id", "Name");
            ViewBag.Persona = new SelectList(db.PV_Persona.ToList(), "Id", "Name");
            ViewBag.BIMUse = new SelectList(db.PV_BIMUse.ToList(), "Id", "Name");
        }

        //private void BindForMatrix(string _ProjType)
        //{
        //    ViewBag.Industry = new SelectList(db.PV_Industry.ToList(), "Name", "Name", _ProjType);
        //    ViewBag.Phase = new SelectList(db.PV_Phase.ToList(), "Name", "Name");
        //    ViewBag.Persona = new SelectList(db.PV_Persona.ToList(), "Name", "Name");
        //}
    }
}
