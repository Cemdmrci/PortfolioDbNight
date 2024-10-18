using PortfolioDbNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioDbNight.Controllers
{
    public class ProfileController : Controller
    {
        MyPortfolioNightEntities context = new MyPortfolioNightEntities();
        public ActionResult Index()
        {
            var values = context.Profile.FirstOrDefault();

            return View(values);
        }

        [HttpPost]
        public ActionResult Index(Profile profile)
        {
            var value = context.Profile.Find(profile.ProfileId);

            value.Birthdate = profile.Birthdate;
            value.Email = profile.Email;
            value.Phone = profile.Phone;
            value.Github = profile.Github;
            value.Address = profile.Address;
            value.Title = profile.Title;
            value.ImageUrl = profile.ImageUrl;
            value.Description = profile.Description;

            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}