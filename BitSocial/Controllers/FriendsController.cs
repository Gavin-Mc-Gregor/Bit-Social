using BitSocial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitSocial.Controllers
{
    public class FriendsController : Controller
    {
        [HttpPost]
        public ActionResult Accept(int UserID)
        {
            var myID = LoggedUser.LoggedUser.GetUser().GetUserID;
            using (DBFriendsModel db = new DBFriendsModel())
            {
                var friendship = db.Friends.Where(x => x.UserID == myID && x.FriendID == UserID).First();
                friendship.Accepted = true;
                
            }
            return RedirectToAction("Requests");
        }
        [HttpPost]
        public ActionResult Decline(int UserID)
        {
            var myID = LoggedUser.LoggedUser.GetUser().GetUserID;
            using (DBFriendsModel db = new DBFriendsModel())
            {
                var friendship = db.Friends.Where(x => x.UserID == myID && x.FriendID == UserID).First();
                db.Friends.Remove(friendship);

            }
            return RedirectToAction("Requests");
        }
        public ActionResult Requests()
        {
            FriendsModel friends = new FriendsModel();
            List<FriendsModel> notificationsList = new List<FriendsModel>();
            notificationsList = friends.GetNotifications();
            return View(notificationsList);
        }
        // GET: Friends
        public ActionResult Friends()
        {
            FriendsModel friends = new FriendsModel();
            List<FriendsModel> friendsList = new List<FriendsModel>();
            friendsList = friends.GetFriends();
            return View(friendsList);
        }
        public ActionResult AddFriends()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddFriends(SearchFriendModel friendEmail)
        {
            if (ModelState.IsValid)
            {
                using (BitSocialEntities db = new BitSocialEntities())
                {
                    try
                    {
                        var exists = db.Users.Where(x => x.Email == friendEmail.Email).First();

                        User friend = exists;
                        User my = db.Users.Find(LoggedUser.LoggedUser.GetUser().GetUserID);
                        using (DBFriendsModel mod = new DBFriendsModel())
                        {
                            Friend newFriend = new Friend
                            {
                                UserID = my.UserID,
                                FriendID = friend.UserID,
                                Accepted = false
                            };
                            mod.Friends.Add(newFriend);
                            mod.SaveChanges();
                          
                            return RedirectToAction("Index","Profile");
                        }
                    }
                    catch
                    {
                        ViewBag.Email = "Friend does not exist, or you have already sent this person a freind request.";
                        return View();
                    }
                }
            }
            return View();
        }
    }
}