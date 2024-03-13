using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TasteFoodit.Controllers
{
    public class ChefDetailController : Controller
    {
        // GET: ChefDetail
        public ActionResult Index()
        {
            string PageName = "Chef";
            TempData["Page"] = PageName;
            return View();
            
        }
    }
}