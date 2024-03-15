using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodit.Entities;
using TasteFoodit.Context;
using System.Web.Security;

namespace TasteFoodit.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        TasteContext context = new TasteContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var values = context.Admins.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.UserName, true);
                Session["a"] = values.UserName;
                return RedirectToAction("ProductList", "Product");
            }
            return View();
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            var values = context.Admins.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.UserName, false);
                Session["UserName"] = values.UserName.ToString();
                return RedirectToAction("Index", "Profile");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
           
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}