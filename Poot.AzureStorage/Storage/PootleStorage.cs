using System.Collections.Generic;
using Poot.AzureStorage.Entities;
using Poot.AzureStorage.Queries;

namespace Poot.AzureStorage.Storage
{
    public class PootleStorage : TableStorage<Pootle>
    {
        public PootleStorage()
            : base(tableName: "pootle")
        {
        }

        public IEnumerable<Pootle> GetAll()
        {
            var query = new AllPootles("","");
            return query.ExecuteOn(Table);
        }

    }
}