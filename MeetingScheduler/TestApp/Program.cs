using DataLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository<User> _userRepo = new Repository<User>();
            Repository<Team> _teamRepo = new Repository<Team>();

            User user = new User();
            user.Username = "smema91";
            user.Firstname = "Natalija";
            user.Lastname = "Nikoletic";
            user.Password = "smema05";
            user.Role = "employee";
            user.Email = "natalija.nikoletic.yahoo.com";
            user.TeamId = 1;

            Team team = new Team();
            team.Name = "Cool Guys Inc.";
            team.Desc = "Best team around";

            //_teamRepo.Insert(team);
            //_userRepo.Insert(user);

            //IEnumerable<Team> teams = _teamRepo.GetAll();
            IEnumerable<User> users = _userRepo.GetAll();
        }
    }
}
