using PortfolioDbNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioDbNight.Controllers
{
    public class DashboardController : Controller
    {
        MyPortfolioNightEntities context = new MyPortfolioNightEntities();

        public ActionResult Index()
        {
            ViewBag.SkillCount = context.Skill.Count();
            ViewBag.EducationCount=context.Education.Count();
            ViewBag.ExperienceCount = context.Experience.Count();
            ViewBag.ServiceCount = context.Service.Count();
            ViewBag.SocialMediaCount = context.SocialMedia.Count();
            ViewBag.MessageCount = context.Contact.Count();
            return View();
        }
    }
}