using OA.DomainEntities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repo.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly StudentDBEntities2 _context;
        private DbSet<T> dbSet;

        //this constructor inject context class
        public Repository(StudentDBEntities2 context)
        {
            this._context = context;
            this.dbSet = _context.Set<T>();
        }

        public void Delete(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                if (_context.Entry(entity).State == EntityState.Detached)
                {
                    dbSet.Attach(entity);
                }
                dbSet.Remove(entity);
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }
        public void Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    throw new ArgumentNullException("entity");
                }

                T entity = dbSet.Find(id);
                Delete(entity);
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }
        public T Get(int id)
        {
            return dbSet.Find(id);
        }
        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }
        public void Insert(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                dbSet.Add(entity);
            }
            catch (DbEntityValidationException dbEX)
            {
                throw new Exception(GetFullErrorText(dbEX), dbEX);
            }
        }
        public void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }
            catch (DbEntityValidationException dbEX)
            {
                throw new Exception(GetFullErrorText(dbEX), dbEX);
            }
        }        
        //function return a string error formatted
        protected string GetFullErrorText(DbEntityValidationException exc)
        {
            var msg = string.Empty;
            foreach (var validationErrors in exc.EntityValidationErrors)
            {
                foreach (var error in validationErrors.ValidationErrors)
                {
                    msg += string.Format("Property {0} Error: {1}", error.PropertyName, error.ErrorMessage) + Environment.NewLine;
                }
            }
            return msg;
        }

    }
}
