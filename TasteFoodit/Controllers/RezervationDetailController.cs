using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TasteFoodit.Controllers
{
    public class RezervationDetailController : Controller
    {
        // GET: RezervationDetail
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialRezervasyon()
        {
            return PartialView();
        }
    }
}