using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodit.Context;
using TasteFoodit.Entities;
namespace TasteFoodit.Controllers
{
    public class DashboardController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult Index()
        {
            ViewBag.v1 = context.Categories.Count();
            ViewBag.v2 = context.Products.Count();
            ViewBag.v3 = context.Chefs.Count();
            ViewBag.v4 = context.Reservations.Where(x=>x.ReservationStatus=="Aktif").Count();
            ViewBag.v5 = context.Products.Where(x => x.Category.CategoryName == "Kahvaltı").Count();
            ViewBag.v6 = context.Products.Where(x => x.Category.CategoryName == "Çorbalar").Count();
            ViewBag.v7 = context.Products.Where(x => x.Category.CategoryName == "Ana Yemekler").Count();
            ViewBag.v8 = context.Products.Where(x => x.Category.CategoryName == "Tatlilar").Count();
            ViewBag.v9 = context.Products.Where(x => x.Category.CategoryName == "Soğuk İçecekler").Count();
            ViewBag.v10 = context.Products.Where(x => x.Category.CategoryName == "Sıcak İçecekler").Count();
            return View();
        }

    }
}