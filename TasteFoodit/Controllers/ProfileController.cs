using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodit.Context;
using TasteFoodit.Entities;

namespace TasteFoodit.Controllers
{
    public class ProfileController : Controller
    {
        TasteContext context = new TasteContext();
      
        public ActionResult Index()
        {
            var values = context.Admins.ToList();
            ViewBag.v = Session["UserName"];
            return View(values);
        }
     

    }
}