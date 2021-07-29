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
    public interface ITeamService
    {
        [OperationContract]
        TeamInfo GetByID(object id);

        [OperationContract]
        List<TeamInfo> GetAll();

        [OperationContract]
        void Insert(TeamInfo teamModel);
    }
}
