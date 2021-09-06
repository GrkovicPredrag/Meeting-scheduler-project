using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessService.Composites
{
    [DataContract]
    public class TeamInfo
    {
        public TeamInfo()
        {
            Users = new List<UserInfo>();
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Desc { get; set; }

        [DataMember]
        public List<UserInfo> Users { get; set; }
    }
}
