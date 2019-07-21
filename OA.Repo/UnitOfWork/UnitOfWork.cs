using OA.DomainEntities.Entities;
using OA.Repo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repo.UnitOfWork
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private StudentDBEntities2 _context;
        private IRepository<T> Repository;

        public UnitOfWork(StudentDBEntities2 context)
        {
            this._context = context;
        }

        public IRepository<T> Repo
        {
            get
            {
                if (this.Repository == null)
                {
                    this.Repository = new Repository<T>(_context);
                }
                return this.Repository;
            }
        }

        public int Complete()
        {
            return this._context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

            if (_context == null)
            {
                return;
            }

            _context.Dispose();
            _context = null;
        }
    }
}
