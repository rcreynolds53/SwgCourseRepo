using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TipCalculator.Models;

namespace TipCalculator.Controllers
{
    public class HomeController : Controller
    {
        //GET: Home
       [HttpGet]
        public ActionResult Tip()
        {

            return View(new CalculateTip());
        }

        [HttpGet]
        public ActionResult Index()
        {
            return RedirectToAction("Tip");

        }

        [HttpPost]
        public ActionResult Tip(CalculateTip model)
        {
            return View("TipForm", model);
        }
    }
}