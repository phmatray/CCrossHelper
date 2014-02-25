using System.Collections.Generic;

namespace CCrossHelper.Lib.Portable.Interfaces
{
    public interface IRepository<T>
    {
        void Create(T entity);
        T Read(int id);
        void Update(T entity);
        void Delete(T entity);
        IEnumerable<T> SelectAll();
    }
}