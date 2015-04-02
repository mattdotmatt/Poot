using System.Collections.Generic;

namespace Poot.AzureStorage
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