using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace BitSocial.Models
{
    public class FriendsModel
    {
        [DisplayName("ID")]
        public int UserID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public List<FriendsModel> GetNotifications()
        {
            List<FriendsModel> notifictationList = new List<FriendsModel>();
            using (DBFriendsModel db = new DBFriendsModel())
            {
                    var UserID = LoggedUser.LoggedUser.GetUser().GetUserID;
                if(db.Friends.Where(x => x.FriendID == UserID && x.Accepted == false).Count() == 0)
                {

                    notifictationList.Add(new FriendsModel { Name="No Notifications", Surname="Yet!", Email = " "});
                    return notifictationList;
                }
                else
                {
                    var query = (from f in db.Friends
                                 where f.FriendID == UserID
                                 && f.Accepted == false
                                 select f).ToList();
                    foreach (var u in query)
                    {
                        using (BitSocialEntities conn = new BitSocialEntities()) { 
                        var user = conn.Users.Find(u.UserID);
                        FriendsModel friend = new FriendsModel
                        {
                            UserID = user.UserID,
                            Name = user.Name,
                            Surname = user.Surname,
                            Email = user.Email,

                        };
                        notifictationList.Add(friend);
                    }
                    }
                }
                return notifictationList;
            }
        }
        public List<FriendsModel> GetFriends()
        {
            List<FriendsModel> FriendsList = new List<FriendsModel>();
            using (DBFriendsModel db = new DBFriendsModel())
            {
                using (BitSocialEntities ent = new BitSocialEntities())
                {
                    var UserID = LoggedUser.LoggedUser.GetUser().GetUserID;
                    if (db.Friends.Where(x => x.UserID == UserID && x.Accepted == true).Count() == 0)
                    {
                        FriendsList.Add(new FriendsModel { Name = "No", Surname = "Friends", Email = "Yet!" });
                        return FriendsList;
                    }
                    else
                    {
                       
                        var query = (from f in db.Friends
                                     where f.UserID == UserID
                                     && f.Accepted == true
                                     select f).ToList();

                        foreach (var f in query)
                        {

                            var user = ent.Users.Find(f.FriendID);
                            FriendsModel friend = new FriendsModel
                            {
                                UserID = user.UserID,
                                Name = user.Name,
                                Surname = user.Surname,
                                Email = user.Email,

                            };
                            FriendsList.Add(friend);
                        }
                    }
                    return FriendsList;
                }
            }
        }

    }
}