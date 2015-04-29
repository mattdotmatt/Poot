using System.Collections.Generic;

namespace Poot.Service.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T model);
        void Add(IEnumerable<T> models);
        
        IList<T> GetAll();
        T Get(string id);

        void Delete(string id);
        void DeleteAll();
    }
}