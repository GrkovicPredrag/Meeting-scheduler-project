using DataAccessService.Contracts;
using DataAccessService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessService
{
    class Program
    {
        static void Main(string[] args)
        {
            /*ServiceHost userSvc = new ServiceHost(typeof(UserService));
            ServiceHost teamSvc = new ServiceHost(typeof(TeamService));
            userSvc.Open();
            teamSvc.Open();*/
            ServiceHost databaseService = new ServiceHost(typeof(DatabaseService));
            //databaseService.AddServiceEndpoint(typeof(IUserService), new NetTcpBinding(), "UserService");
            //databaseService.AddServiceEndpoint(typeof(ITeamService), new NetTcpBinding(), "TeamService");
            databaseService.Open();

            Console.WriteLine("Pritisnite [Enter] za zaustavljanje servisa.");
            Console.ReadLine();
        }
    }
}
