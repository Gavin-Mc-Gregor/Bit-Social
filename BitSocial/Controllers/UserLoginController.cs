using BitSocial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitSocial.LoggedUser;

namespace BitSocial.Controllers
{
    public class UserLoginController : Controller
    {
        // GET: UserLogin
        public ActionResult Index()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Authorise( User user)
        {
            using(BitSocialEntities ent = new BitSocialEntities()){
                var isUser = ent.Users.Where(e => e.Email == user.Email && e.Password == user.Password).FirstOrDefault();
                if (isUser == null)
                {
                    ViewBag.NoUser = "Invalid user credentials";
                    return View("Index", user);
                }
                else
                {
                    var logged = ent.Users.Where(x => x.Email == user.Email).First();
                    LoggedUser.LoggedUser.GetUser().SetUserID(logged.UserID);
                    Session["UserID"] = user.UserID;
                    return RedirectToAction("Index", "Profile");
                }
            }
           
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "UserLogin");
        }
       
    }
}