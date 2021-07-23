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
    public class UserService : IUserService
    {
        private readonly UserRepository _repo;
        private readonly ILogger _logger;
        private readonly UserMapper _mapper;

        public UserService()
        {
            _repo = new UserRepository();
            _logger = LoggerFactory.Create(LoggerFactory.LoggingOption.Output);
            _mapper = new UserMapper();
        }

        public UserInfo GetByID(object id)
        {
            throw new NotImplementedException();
        }

        public List<UserInfo> GetAll()
        {
            List<UserInfo> userInfo = new List<UserInfo>();
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

            return userInfo;
        }

        public void Insert(UserInfo userModel)
        {
            throw new NotImplementedException();
        }

        public void whatwhat()
        {

        }
    }
}
