using DataService.Composites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Contracts
{
    [ServiceContract]
    public interface IUserService
    {
        UserInfo GetByID(object id);

        List<UserInfo> GetAll();

        void Insert(UserInfo userModel);
    }
}
