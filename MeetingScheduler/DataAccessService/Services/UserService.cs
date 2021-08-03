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
    public class UserService
    {
        private readonly UserRepository _repo;
        protected readonly UserMapper _mapper;
        private readonly ILogger _logger;
        private object lockObj;

        public UserService(object lockobject)
        {
            _repo = new UserRepository();
            _mapper = new UserMapper();
            _logger = LoggerFactory.Create(LoggerFactory.LoggingOption.Output);
            lockObj = lockobject;
        }

        public UserInfo GetByID(object id)
        {
            throw new NotImplementedException();
        }

        public List<UserInfo> GetAll()
        {
            List<UserInfo> userInfo = new List<UserInfo>();
            lock(lockObj)
            {
                try
                {
                    var users = _repo.GetAll();
                    userInfo = _mapper.MapCollection(users);
                    _logger.Log("Successfully created userInfo [GetAll]");
                }
                catch (Exception ex)
                {
                    _logger.Log(ex.Message.ToString());
                }
            }
            return userInfo;
        }

        public void Insert(UserInfo userModel)
        {
            throw new NotImplementedException();
        }
    }
}
