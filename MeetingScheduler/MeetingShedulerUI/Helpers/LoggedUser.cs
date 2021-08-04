using MeetingShedulerUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingShedulerUI.Helpers
{
    public sealed class LoggedUser
    {
        LoggedUser() { }
        private static readonly object lockObj = new object ();  
        private static LoggedUser instance = null;
        public static LoggedUser Instance
        {
            get
            {
                lock (lockObj)
                    {
                        if (instance == null)
                        {
                            instance = new LoggedUser();
                        }
                        return instance;
                    }
            }
        }

        public UserModel User { get; set; }

    }
}
