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
        UserInfo GetByID(object id);

        [OperationContract]
        List<UserInfo> GetAll();

        [OperationContract]
        void Insert(UserInfo userModel);

        [OperationContract]
        void whatwhat();
    }
}
