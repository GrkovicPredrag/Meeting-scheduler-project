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

            ServiceHost svc = new ServiceHost(typeof(UserService));
            svc.Open();

            Console.WriteLine("Pritisnite [Enter] za zaustavljanje servisa.");
            Console.ReadLine();
        }
    }
}
