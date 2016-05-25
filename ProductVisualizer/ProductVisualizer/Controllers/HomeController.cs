using ProductVisualizer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProductVisualizer.Controllers
{
    public class HomeController : Controller
    {
        private ProductVisualizerEntities db = new ProductVisualizerEntities();

        public ActionResult Index(string SearchValue, string CoulmnType)
        {
            ViewBag.ProjectType = new SelectList(db.PV_Industry.ToList(), "Id", "Name");

            List<AllDetail> lstProdcut;
            if (string.IsNullOrEmpty(SearchValue))
                lstProdcut = db.AllDetails.ToList();
            else
                lstProdcut = db.AllDetails.Where(ex => ex.Name.Contains(SearchValue)).ToList();

            if (!string.IsNullOrEmpty(CoulmnType))
                lstProdcut = lstProdcut.Where(ex => ex.Description.Contains(CoulmnType)).ToList();

            return View(lstProdcut);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}