using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessService.Composites
{
    [DataContract]
    public class UserInfo
    {
        public UserInfo()
        {
            Team = new TeamInfo();
        }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Firstname { get; set; }

        [DataMember]
        public string Lastname { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Role { get; set; }

        [DataMember]
        public TeamInfo Team { get; set; }

    }
}
