using PortfolioDbNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioDbNight.Controllers
{
    public class AboutController : Controller
    {
        MyPortfolioNightEntities context = new MyPortfolioNightEntities();
        [HttpGet]
        public ActionResult AboutList()
        {
            var values = context.About.FirstOrDefault();
            return View(values);
        }
        [HttpPost]
        public ActionResult AboutList(About about)
        {
            var eski = context.About.Find(about.AboutId);
            eski.Title = about.Title;
            eski.Description = about.Description;
            eski.ImageUrl = about.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("AboutList");
        }
    }
}