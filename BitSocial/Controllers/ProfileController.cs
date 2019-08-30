using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitSocial.Models;

namespace BitSocial.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {
            using (BitSocialEntities ent = new BitSocialEntities())
            {
                var isUser = ent.Users.Find(LoggedUser.LoggedUser.GetUser().GetUserID);
                EditProfile edit = new EditProfile();
                edit.Name = isUser.Name;
                edit.Surname = isUser.Surname;
                edit.Email = isUser.Email;
                return View(edit);
            }
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(EditProfile user)
        {
            if (ModelState.IsValid)
            {
                using (BitSocialEntities db = new BitSocialEntities())
                {
                    var oldUser = db.Users.Find(LoggedUser.LoggedUser.GetUser().GetUserID);
                    oldUser.Name = user.Name;
                    oldUser.Surname = user.Surname;
                    oldUser.Email = oldUser.Email;
                    if (oldUser.Email == user.Email)
                    {
                        db.Entry(oldUser).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        if (db.Users.Any(x => x.Email == user.Email))
                        {
                            ViewBag.DuplicateMessage = "This Email address is already in use!";
                            return View("Index", user);
                        }
                        else
                        {
                            oldUser.Email = user.Email;
                            db.Entry(oldUser).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                }

                ModelState.Clear();
                ViewBag.SuccessMessage = "Update Successful.";
                return RedirectToAction("Index", "Profile");
            }
            return View();
        }


    }
}
