using DataLayer.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class UserRepository : Repository<User>
    {
        public override IEnumerable<User> GetAll()
        {
            IEnumerable<User> toReturn = null;
            try
            {
                toReturn = _table
                    .Include(x => x.Activities)
                    .Include(x => x.Team)
                    .Include(x => x.Vacations)
                    .Include(x => x.UserMeetings)
                    .ToList();

                _logger.Log("Succesfully returned users! [GetAll]");
            }
            catch (Exception ex)
            {
                _logger.Log(ex.Message.ToString());
            }
            return toReturn;
        }

        public override User GetByID(object id)
        {
            User toReturn = new User();
            try
            {
                toReturn = _table
                    .Include(x => x.Activities)
                    .Include(x => x.Team)
                    .Include(x => x.Vacations)
                    .Include(x => x.UserMeetings)
                    .Where(x => (string)id == x.Username)
                    .FirstOrDefault();

                _logger.Log("Succesfully returned users! [GetAll]");
            }
            catch (Exception ex)
            {
                _logger.Log(ex.Message.ToString());
            }
            return toReturn;
        }
    }
}
