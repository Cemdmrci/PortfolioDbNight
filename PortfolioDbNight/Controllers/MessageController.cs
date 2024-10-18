using PortfolioDbNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioDbNight.Controllers
{
    public class MessageController : Controller
    {
        MyPortfolioNightEntities context = new MyPortfolioNightEntities();
        public ActionResult Inbox()
        {
            var values = context.Contact.ToList();
            return View(values);
        }
        public ActionResult ChangeMessageStatuesToTrue(int id)
        {
            var value = context.Contact.Find(id);
            value.IsRead = true;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }
        public ActionResult ChangeMessageStatuesToFalse(int id)
        {
            var value = context.Contact.Find(id);
            value.IsRead = false;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }

    }
}