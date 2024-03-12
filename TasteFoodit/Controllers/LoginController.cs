﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodit.Entities;
using TasteFoodit.Context;
using System.Web.Security;

namespace TasteFoodit.Controllers
{
    public class LoginController : Controller
    {
        TasteContext context = new TasteContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin a)
        {
            var values = context.Admins.FirstOrDefault(x => x.UserName == a.UserName && x.Password == a.Password);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.UserName, true);
                Session["a"] = values.UserName;
                return RedirectToAction("ProductList", "Product");
            }
            return View();
        }
    }
}