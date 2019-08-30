using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitSocial.LoggedUser
{
    public class LoggedUser
    { 
        public int _LoggedUserID;
        private static LoggedUser uniqueInstance;
        private LoggedUser()
        {
        }
        public static LoggedUser GetUser()
        {
            if(uniqueInstance == null)
            {
                uniqueInstance = new LoggedUser();
            }
            return uniqueInstance;
        }
        public int GetUserID
        {
            get
            {
                return _LoggedUserID;
            }
        }
        public void SetUserID(int i)
        {
            _LoggedUserID = i;
        }
    }
}