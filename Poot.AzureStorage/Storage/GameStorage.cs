using System.Collections.Generic;
using Poot.AzureStorage.Entities;
using Poot.AzureStorage.Queries;

namespace Poot.AzureStorage.Storage
{
    public class GameStorage : TableStorage<Game>
    {
        public GameStorage()
            : base(tableName: "game")
        {
        }

        public IEnumerable<Pootle> GetAll()
        {
            var query = new AllPootles("","");
            return query.ExecuteOn(Table);
        }

    }
}