using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Data
{
    public class SchedulerContext : DbContext
    {
        public SchedulerContext() : base()
        {

        }

        public virtual DbSet<Holiday> Holidays { get; set; }
        public virtual DbSet<Vacation> Vacations { get; set; }
        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<Meeting> Meetings { get; set; }
        public virtual DbSet<UserMeeting> UserMeetings { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
    }
}
