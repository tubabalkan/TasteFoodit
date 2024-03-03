using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodit.Context;
using TasteFoodit.Entities;
namespace TasteFoodit.Controllers
{
    public class AdminController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult AdminList()
        {
            var values = context.Admins.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateAdmin()
        {
            List<SelectListItem> values = (from x in context.Admins.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UserName,
                                               Value = x.AdminId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }
        [HttpPost]
        public ActionResult CreateAdmin(Admin a)
        {

            context.Admins.Add(a);
            context.SaveChanges();
            return RedirectToAction("AdminList");

        }
        public ActionResult DeleteAdmin(int id)
        {
            var value = context.Admins.Find(id);
            context.Admins.Remove(value);
            context.SaveChanges();
            return RedirectToAction("AdminList");
        }
        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            var value = context.Admins.Find(id);

            List<SelectListItem> admins = (from x in context.Admins.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.UserName,
                                              Value = x.AdminId.ToString()
                                          }).ToList();
            ViewBag.v = admins;
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateAdmin(Admin a)
        {
            var value = context.Admins.Find(a.AdminId);
            value.AdminId = a.AdminId;
            value.UserName = a.UserName;
            value.Password = a.Password;
            
            context.SaveChanges();
            return RedirectToAction("AdminList");


        }
    }
}