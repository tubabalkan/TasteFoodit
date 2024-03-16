using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodit.Context;
using TasteFoodit.Entities;
namespace TasteFoodit.Controllers
{
    public class ContactDetailController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialBilgi()
        {
            return PartialView();
        }
        [HttpGet]
        public PartialViewResult PartialMessage()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult PartialMessage(Contact c)
        {
            c.SendDate = DateTime.Now;
            context.Contacts.Add(c);
            context.SaveChanges();
            return PartialView();
        }
    }
}