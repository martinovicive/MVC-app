using Aplikacija.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Aplikacija.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Zaposlenik model)
        {
            using (var context = new SeminarDbContext())
            {
                bool isValid = context.Zaposlenik.Any(x => x.KorisnickoIme == model.KorisnickoIme && x.Password == model.Password);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.KorisnickoIme, false);
                    return RedirectToAction("Index", "Predbiljezba");
                }
                ModelState.AddModelError("","Krivo korisničko ime ili lozinka!");
                return View();
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}