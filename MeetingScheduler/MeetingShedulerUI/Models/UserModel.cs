using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingShedulerUI.Models
{
    public class UserModel
    {
        public UserModel()
        {
            Team = new TeamModel();
        }

        public string Username { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public TeamModel Team { get; set; }
    }
}
