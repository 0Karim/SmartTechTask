using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repo.Repository
{
    public interface IRepository<T> where T : class
    {
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
        void Insert(T entity);
        IEnumerable<T> GetAll();
        T Get(int id);
    }
}
