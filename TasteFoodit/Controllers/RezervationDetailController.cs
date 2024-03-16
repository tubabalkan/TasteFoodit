using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodit.Context;
using TasteFoodit.Entities;


namespace TasteFoodit.Controllers
{
    public class RezervationDetailController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult PartialRezervasyon()
        {

            return PartialView();
        }
      
        [HttpPost]
        public PartialViewResult PartialRezervasyon(Reservation r)
        {
            context.Reservations.Add(r);
            context.SaveChanges();
            return PartialView();
        }
    }
}