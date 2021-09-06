using DataAccessService.Composites;
using DataAccessService.Contracts;
using DataAccessService.Mappers;
using DataLayer.Repositories;
using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessService.Services
{
    public class TeamService
    {
        private readonly TeamRepository _repo;
        private readonly ILogger _logger;
        private readonly TeamMapper _mapper;
        private object lockObj;

        public TeamService(object lockobject)
        {
            _repo = new TeamRepository();
            _logger = LoggerFactory.Create(LoggerFactory.LoggingOption.Output);
            _mapper = new TeamMapper();
            lockObj = lockobject;
        }

        public TeamInfo GetByID(object id)
        {
            throw new NotImplementedException();
        }

        public List<TeamInfo> GetAll()
        {
            List<TeamInfo> teamInfo = new List<TeamInfo>();

            lock (lockObj)
            {               
                try
                {
                    var teams = _repo.GetAll();
                    teamInfo = _mapper.MapCollection(teams);
                    _logger.Log("Successfully created teamInfo! [GetAll]");
                }
                catch (Exception ex)
                {
                    _logger.Log(ex.Message.ToString());
                }
            }
            
            return teamInfo;
        }

        public void Insert(TeamInfo teamModel)
        {
            throw new NotImplementedException();
        }
    }
}
