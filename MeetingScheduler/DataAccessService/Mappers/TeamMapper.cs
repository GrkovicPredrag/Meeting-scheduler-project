using DataAccessService.Composites;
using DataLayer.Data;
using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessService.Mappers
{
    public class TeamMapper
    {
        private readonly ILogger _logger;
        public TeamMapper()
        {
            _logger = LoggerFactory.Create(LoggerFactory.LoggingOption.Output);
        }

        public TeamInfo Map(Team team)
        {
            TeamInfo teamInfo = new TeamInfo();
            try
            {
                teamInfo.Name = team.Name;
                teamInfo.Desc = team.Desc;
                teamInfo.Users = MapUsers(team.Users);
                _logger.Log("Succesful User to UserInfo mapping! [Map]");
            }
            catch (Exception ex)
            {
                _logger.Log(ex.Message.ToString());
            }

            return teamInfo;
        }

        public List<TeamInfo> MapCollection(IEnumerable<Team> teams)
        {
            List<TeamInfo> teamInfo = new List<TeamInfo>();
            try
            {
                foreach (var Team in teams)
                {
                    teamInfo.Add(Map(Team));
                }
                _logger.Log("Succesful Team collection to TeamInfo list mapping! [MapCollection]");
            }
            catch (Exception ex)
            {
                _logger.Log(ex.Message.ToString());
            }

            return teamInfo;
        }

        private List<UserInfo> MapUsers(IEnumerable<User> users)
        {
            List<UserInfo> userInfo = new List<UserInfo>();
            try
            {
                foreach (var user in users)
                {
                    userInfo.Add(MapUser(user));
                }
                _logger.Log("Succesfully partially added users in teamMapper! [MapUsers]");
            }
            catch (Exception ex)
            {
                _logger.Log(ex.Message.ToString());
            }

            return userInfo;
        }

        private UserInfo MapUser(User user)
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
                _logger.Log("Succesful partial user mapping [MapUser]");
            }
            catch (Exception ex)
            {
                _logger.Log(ex.Message.ToString());
            }

            return userInfo;
        }
    }
}
