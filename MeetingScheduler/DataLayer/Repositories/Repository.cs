using DataLayer.Data;
using DataLayer.Interfaces;
using Logger;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected SchedulerContext _context = null;
        protected DbSet<TEntity> _table = null;
        protected ILogger _logger = null;

        public Repository()
        {
            _context = new SchedulerContext();
            _table = _context.Set<TEntity>();
            _logger = LoggerFactory.Create(LoggerFactory.LoggingOption.Output);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            IEnumerable<TEntity> toReturn = null;
            try
            {
                toReturn = _table.ToList();
                _logger.Log("Succesfully returned objects! [GetAll]");
            }
            catch (Exception ex)
            {
                _logger.Log(ex.Message.ToString());
            }
            return toReturn;
        }

        public void Insert(TEntity entity)
        {
            try
            {
                _table.Add(entity);
                _context.SaveChanges();
                _logger.Log("Successfully added entity. [Insert]");
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var errors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in errors.ValidationErrors)
                    {
                        // get the error message 
                        string errorMessage = validationError.ErrorMessage;
                        _logger.Log(errorMessage);
                    }
                }
            }
        }

        public void Delete(object id)
        {

        }

        public void Update(TEntity entity)
        {

        }

        public virtual TEntity GetByID(object id)
        {
            TEntity toReturn = null;
            try
            {
                toReturn = _table.FirstOrDefault();
                _logger.Log("Succesfully returned objects! [GetAll]");
            }
            catch (Exception ex)
            {
                _logger.Log(ex.Message.ToString());
            }
            return toReturn;
        }
    }
}
