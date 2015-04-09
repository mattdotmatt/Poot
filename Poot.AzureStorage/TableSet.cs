using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace Poot.AzureStorage
{
    public class TableSet<TEntity>
    where TEntity : ITableEntity,
        new()
    {
        private List<dynamic> internalList;
        private string partitionKey;
        private string tableName;
        private string connectionString;

        internal CloudTableClient tableClient;
        internal CloudTable table;

        public TableSet(string connectionString, string tableName)
        {
            this.partitionKey = typeof(TEntity).Name;
            this.tableName = tableName;
            this.connectionString = connectionString;

            //pluralise the partition key (because basically it is the 'table' name).
            if (partitionKey.Substring(partitionKey.Length - 1, 1).ToLower() == "y")
                partitionKey = partitionKey.Substring(0, partitionKey.Length - 1) + "ies";

            if (partitionKey.Substring(partitionKey.Length - 1, 1).ToLower() != "s")
                partitionKey = partitionKey + "s";

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
            tableClient = storageAccount.CreateCloudTableClient();
            table = tableClient.GetTableReference(tableName);
            table.CreateIfNotExists();
        }

        public virtual ITableEntity GetByID(object id)
        {
            var query = new TableQuery().Where(TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.Equal, id.ToString()));
            var result = table.ExecuteQuery(query).First();

            return result;
        }

        public virtual List<ITableEntity> GetAll()
        {
            var query = new TableQuery().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionKey)); //get all customers - because Customer is our partition key
            return null; //table.ExecuteQuery(query).ToList();
        }

        public virtual void Insert(TEntity entity)
        {
            TableOperation insertOperation = TableOperation.Insert(entity);
            table.Execute(insertOperation);
        }
    }
}