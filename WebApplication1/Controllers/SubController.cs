using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SubController : Controller
    {
        NewsPaperSystemEntities1 db = new NewsPaperSystemEntities1();

        // GET: VendorLists
        public ActionResult Subcr()
        {
            return View(db.Subscriptions.ToList());
        }
    }
}
