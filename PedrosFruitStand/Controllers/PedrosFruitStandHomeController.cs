using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PedrosFruitStand.Models;

namespace PedrosFruitStand.Controllers
{
    public class PedrosFruitStandHomeController : Controller
    {
        PFS pfs = null;
        // GET: PedrosFruitStandHome
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Requirement1()
        {
            return View();
        }

        public ActionResult Requirement2()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetFruitTotals(List<Models.FruitStandStuff> fruitlist, string toDate, string fromDate)
        {
            pfs = new PFS();
            var result = pfs.TotalsByDateRange(fruitlist, toDate, fromDate);

            return Json(result, JsonRequestBehavior.AllowGet); 
        }
    }
}