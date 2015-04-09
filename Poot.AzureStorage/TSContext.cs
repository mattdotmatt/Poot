using Microsoft.WindowsAzure.Storage.Table;

namespace Poot.AzureStorage
{
    public abstract class TSContext
    {
        private string tableName { get; set; }
        private string connectionString { get; set; }

        public TSContext(string connectionString, string tableName)
        {
            this.tableName = tableName;
            this.connectionString = connectionString;
        }

        public virtual TableSet<TEntity> Set<TEntity>()
            where TEntity : ITableEntity, new()
        {
            var set = new TableSet<TEntity>(connectionString, tableName);

            return set;
        }
    }
}