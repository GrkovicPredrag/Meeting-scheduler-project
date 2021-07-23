using DataAccessService.Composites;
using DataAccessService.Contracts;
using DataLayer.Data;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Repository<User> _userRepo = new UserRepository();
            Repository<Team> _teamRepo = new TeamRepository();

            User user = new User();
            user.Username = "smema91";
            user.Firstname = "Natalija";
            user.Lastname = "Nikoletic";
            user.Password = "smema05";
            user.Role = "employee";
            user.Email = "natalija.nikoletic.yahoo.com";
            user.TeamId = 1;

            Team team = new Team();
            team.Name = "BTE";
            team.Desc = "Wohoo";

            //_teamRepo.Insert(team);
            //_userRepo.Insert(user);

            //IEnumerable<Team> teams = _teamRepo.GetAll();
            IEnumerable<User> users = _userRepo.GetAll();*/

            ChannelFactory<IUserService> factory = new ChannelFactory<IUserService>(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:4000/IUserService"));

            IUserService proxy = factory.CreateChannel();

            List<UserInfo> list = new List<UserInfo>();

            list = proxy.GetAll();

        }
    }
}
 