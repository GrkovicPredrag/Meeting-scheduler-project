using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingShedulerUI.Models
{
    public class TeamModel
    {
        public TeamModel()
        {
            Users = new List<UserModel>();
        }

        public string Name { get; set; }
        public string Desc { get; set; }
        public List<UserModel> Users { get; set; }
    }
}
