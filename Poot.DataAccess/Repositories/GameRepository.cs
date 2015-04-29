using Poot.Models;

namespace Poot.DAL.Repositories
{
    /// <summary>
    /// Azure Table Storage
    /// </summary>
    public class GameRepository : BaseRepository<Game, Entities.Game>
    {
        protected override string TableName
        {
            get { return "game"; }
        }

        protected override string PartitionKey
        {
            get { return "game"; }
        }

        protected override Entities.Game AddEntityData(Game model, Entities.Game entity)
        {
            entity.PartitionKey = PartitionKey;
            entity.RowKey = model.Name;
            return entity;
        }
    }
}