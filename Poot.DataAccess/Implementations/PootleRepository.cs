using System;
using System.Collections.Generic;
using Poot.DataAccess.Interfaces;
using Poot.Models;

namespace Poot.DataAccess.Implementations
{
    public class Repository<T> : IRepository<Pootle>
    {
        public IEnumerable<Pootle> GetAll()
        {
            throw new NotImplementedException();
        }

        public Pootle Create(Pootle objectToCreate)
        {
            throw new NotImplementedException();
        }
    }
}