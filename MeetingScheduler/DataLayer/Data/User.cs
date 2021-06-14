using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Data
{
    public class User
    {
        public User()
        {
            Vacations = new HashSet<Vacation>();
            Activities = new HashSet<Activity>();
            UserMeetings = new HashSet<UserMeeting>();
        }

        [Key]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Firstname { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Lastname { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Password { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Role { get; set; }

        public int TeamId { get; set; }

        public virtual Team Team { get; set; }

        public virtual ICollection<Vacation> Vacations { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<UserMeeting> UserMeetings { get; set; }

    }
}
