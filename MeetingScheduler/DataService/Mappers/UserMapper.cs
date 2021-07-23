using DataLayer.Data;
using DataService.Composites;
using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataService.Mappers
{
    public class UserMapper
    {
        private readonly ILogger _logger;
        public UserMapper()
        {
            _logger = LoggerFactory.Create(LoggerFactory.LoggingOption.Output);
        }

        public UserInfo Map(User user)
        {
            UserInfo userInfo = new UserInfo();
            try
            {
                userInfo.Username = user.Username;
                userInfo.Firstname = user.Firstname;
                userInfo.Lastname = user.Lastname;
                userInfo.Password = user.Password;
                userInfo.Email = user.Email;
                userInfo.Role = user.Role;
                _logger.Log("Succesful User to UserInfo mapping! [Map]");
            }
            catch (Exception ex)
            {
                _logger.Log(ex.Message.ToString());
            }

            return userInfo;
        }

        public List<UserInfo> MapCollection(IEnumerable<User> users)
        {
            List<UserInfo> userInfo = new List<UserInfo>();
            try
            {
                foreach(var user in users)
                {
                    userInfo.Add(Map(user));
                }
                _logger.Log("Succesful User collection to UserInfo list mapping! [MapCollection]");
            }
            catch (Exception ex)
            {
                _logger.Log(ex.Message.ToString());
            }

            return userInfo;
        }
    }
}