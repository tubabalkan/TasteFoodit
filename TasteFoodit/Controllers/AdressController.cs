using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodit.Context;
using TasteFoodit.Entities;
namespace TasteFoodit.Controllers
{
    public class AdressController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult AdresList()
        {
            var values = context.Addresses.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateAdress()
        {
            List<SelectListItem> values = (from x in context.Addresses.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Description,
                                               Value = x.AddressId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }
        [HttpPost]
        public ActionResult CreateAdress(Address a)
        {

            context.Addresses.Add(a);
            context.SaveChanges();
            return RedirectToAction("AdresList");

        }
        public ActionResult DeleteAdres(int id)
        {
            var value = context.Addresses.Find(id);
            context.Addresses.Remove(value);
            context.SaveChanges();
            return RedirectToAction("AdresList");
        }
        [HttpGet]
        public ActionResult UpdateAdres(int id)
        {
            var value = context.Addresses.Find(id);

            List<SelectListItem> adress = (from x in context.Addresses.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.Phone,
                                              Value = x.AddressId.ToString()
                                          }).ToList();
            ViewBag.v = adress;
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateAdres(Address a)
        {
            var value = context.Addresses.Find(a.AddressId);
            value.AddressId =a.AddressId;
            value.Phone = a.Phone;
            value.Email = a.Email;
           
            value.Description = a.Description;
            context.SaveChanges();
            return RedirectToAction("AdresList");
        }
    }
}