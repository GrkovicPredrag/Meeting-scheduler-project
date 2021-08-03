using DataAccessService.Composites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessService.Contracts
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        UserInfo GetUserByID(object id);

        [OperationContract]
        List<UserInfo> GetAllUsers();

        [OperationContract]
        void InsertUser(UserInfo userModel);
    }
}
