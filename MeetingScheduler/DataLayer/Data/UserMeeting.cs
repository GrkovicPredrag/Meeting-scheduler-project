using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Data
{
    public class UserMeeting
    {
        [Key]
        public int Id { get; set; }
        public string UserUsername { get; set; }
        public int MeetingId { get; set; }

        public virtual Meeting Meeting { get; set; }
        public virtual User User { get; set; }
    }
}
