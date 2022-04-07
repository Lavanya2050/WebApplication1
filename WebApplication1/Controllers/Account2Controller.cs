using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Web.Security;



namespace WebApplication1.Controllers
{
    public class Account2Controller : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserLogin model)

        {
            using (var context = new NewsPaperSystemEntities1())
            {
                bool isVaild = context.UserLogins.Any(x => x.UserType == model.UserType && x.UserName == model.UserName && x.PassWord == model.PassWord);
                if (isVaild)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Create", "New");
                }
                
                return View();
            }
        }

        public ActionResult singup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult singup(UserLogin model)

        {
            using (var context = new NewsPaperSystemEntities1())
            {
                context.UserLogins.Add(model);
                context.SaveChanges();
                return RedirectToAction("Login");
            }
        }
        public ActionResult Logout()

        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }

}
