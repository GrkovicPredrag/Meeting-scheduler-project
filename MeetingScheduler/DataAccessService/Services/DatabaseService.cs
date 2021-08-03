using DataAccessService.Composites;
using DataAccessService.Contracts;
using DataAccessService.Mappers;
using DataLayer.Repositories;
using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessService.Services
{
    public class DatabaseService : ITeamService, IUserService
    {
        #region fields
        public static readonly object lockObj = new object();

        private readonly UserService _userService;
        private readonly TeamService _teamService;
        #endregion

        public DatabaseService()
        {
            _userService = new UserService(lockObj);
            _teamService = new TeamService(lockObj);
        }

        #region userService
        public virtual UserInfo GetUserByID(object id)
        {
            throw new NotImplementedException();
        }


        public virtual List<UserInfo> GetAllUsers()
        {
            return _userService.GetAll();
        }


        public virtual void InsertUser(UserInfo userModel)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region teamService
        public TeamInfo GetTeamByID(object id)
        {
            throw new NotImplementedException();
        }

        public List<TeamInfo> GetAllTeams()
        {
            return _teamService.GetAll();
        }

        public void InsertTeam(TeamInfo teamModel)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
