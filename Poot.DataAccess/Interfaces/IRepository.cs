using System.Collections.Generic;

namespace Poot.DataAccess.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Create(T objectToCreate);
    }
}