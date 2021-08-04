using DataAccessService.Composites;
using Logger;
using MeetingShedulerUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingShedulerUI.Helpers.Mappers
{
    public class UserMapper : IDisposable
    {
        private readonly ILogger _logger;
        public UserMapper()
        {
            _logger = LoggerFactory.Create(LoggerFactory.LoggingOption.Output);
        }

        public UserModel Map(UserInfo user)
        {
            UserModel userModel = new UserModel();
            try
            {
                userModel.Username = user.Username;
                userModel.Firstname = user.Firstname;
                userModel.Lastname = user.Lastname;
                userModel.Password = user.Password;
                userModel.Email = user.Email;
                userModel.Role = user.Role;
                userModel.Team = MapTeam(user.Team);
                _logger.Log("Succesful UserInfo to UserModel mapping! [Map]");
            }
            catch (Exception ex)
            {
                _logger.Log(ex.Message.ToString());
            }

            return userModel;
        }

        private TeamModel MapTeam(TeamInfo team)
        {
            TeamModel teamModel = new TeamModel();
            try
            {
                teamModel.Name = team.Name;
                teamModel.Desc = team.Desc;
                _logger.Log("Succesful partial teamModel mapping! [MapTeam]");
            }
            catch (Exception ex)
            {
                _logger.Log(ex.Message.ToString());
            }

            return teamModel;
        }

        public List<UserModel> MapCollection(IEnumerable<UserInfo> users)
        {
            List<UserModel> userModels = new List<UserModel>();
            try
            {
                foreach (var user in users)
                {
                    userModels.Add(Map(user));
                }
                _logger.Log("Succesful User collection to UserInfo list mapping! [MapCollection]");
            }
            catch (Exception ex)
            {
                _logger.Log(ex.Message.ToString());
            }

            return userModels;
        }

        public void Dispose()
        {
            
        }
    }
}
