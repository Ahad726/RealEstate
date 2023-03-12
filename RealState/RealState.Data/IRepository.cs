using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Data
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Edit(T entity);
        T GetById(int id);
        IList<T> GetAll();
        void Remove(int id);
        void Remove(T entity);
    }
}
