using BitSocial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitSocial.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult AddOrEdit(int id = 0)
        {
            User user = new User();
            return View(user);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddOrEdit(User user)
        {
            if (ModelState.IsValid)
            {
                using (BitSocialEntities db = new BitSocialEntities())
                {
                    if (db.Users.Any(x => x.Email == user.Email))
                    {
                        ViewBag.DuplicateMessage = "This Email address is already in use!";
                        return View("AddOrEdit", user);
                    }
                    else
                    {
                        db.Users.Add(user);
                        db.SaveChanges();
                    }
                }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successful.";
            return RedirectToAction("Index", "UserLogin");
            }
            else
            {
                ViewBag.SuccessMessage = "Registration unsuccessful";
                return View();
            }
           
        }
        
        public ActionResult Password()
        {
            ChangePassword password = new ChangePassword();
            return View(password);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Password(ChangePassword password)
        {
            if(ModelState.IsValid){

                using (BitSocialEntities db = new BitSocialEntities())
                {
                    var currUser = db.Users.Find(LoggedUser.LoggedUser.GetUser().GetUserID);

                    if (currUser.Password == password.CurrentPassword)
                    {
                        currUser.Password = password.NewPassword;
                        db.Entry(currUser).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index", "Profile");
                    }
                    else
                    {
                        ViewBag.IncorrectPassword = "Invalid Password";
                        return View("Password",password);
                    }

                }

            }
           
            return View();
        }

    }
}