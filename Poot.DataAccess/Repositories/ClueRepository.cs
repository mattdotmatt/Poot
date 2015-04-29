using Poot.DAL.Entities;

namespace Poot.DAL.Repositories
{
    /// <summary>
    /// Azure Table Storage
    /// </summary>
    public class ClueRepository : BaseRepository<Models.Clue, Clue>
    {
        private readonly string _partitionKey;

        public ClueRepository(params string[] config) : base()
        {
            _partitionKey = config[0];
        }

        protected override string TableName
        {
            get { return "clue"; }
        }

        protected override string PartitionKey
        {
            get { return _partitionKey; }
        }

        protected override Clue AddEntityData(Models.Clue model, Clue entity)
        {
            entity.PartitionKey = _partitionKey;
            entity.RowKey = string.Format("Clue_{0}", model.Name);
            return entity;
        }
    }
}