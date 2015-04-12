using System.Collections.Generic;

namespace Poot.Service.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Delete(string id);
        IList<T> GetAll();
        T Get(string id);
    }
}