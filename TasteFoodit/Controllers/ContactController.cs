using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodit.Context;
using TasteFoodit.Entities;
namespace TasteFoodit.Controllers
{
    public class ContactController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult ContactList()
        {
            var values = context.Contacts.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateContact()
        {
            List<SelectListItem> values = (from x in context.Contacts.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.NameSurname,
                                               Value = x.ContactId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }
        [HttpPost]
        public ActionResult CreateContact(Contact a)
        {

            context.Contacts.Add(a);
            context.SaveChanges();
            return RedirectToAction("ContactList");

        }
        public ActionResult DeleteContact(int id)
        {
            var value = context.Contacts.Find(id);
            context.Contacts.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ContactList");
        }
        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var value = context.Contacts.Find(id);

            List<SelectListItem> contact = (from x in context.Contacts.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.NameSurname,
                                               Value = x.ContactId.ToString()
                                           }).ToList();
            ViewBag.v = contact;
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateContact(Contact a)
        {
            var value = context.Contacts.Find(a.ContactId);
            value.ContactId = a.ContactId;
            value.NameSurname = a.NameSurname;
            value.Email = a.Email;
            value.Subject = a.Subject;
            value.Message= a.Message;
            value.SendDate= a.SendDate;
            context.SaveChanges();
            return RedirectToAction("ContactList");
        }

    }
}