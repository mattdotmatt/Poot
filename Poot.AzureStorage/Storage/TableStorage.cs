using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace Poot.AzureStorage.Storage
{
    public class TableStorage<T> where T : ITableEntity, new()
    {
        public TableStorage(string tableName, string connectionName = "StorageConnectionString")
        {
            var storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting(connectionName));
            var tableClient = storageAccount.CreateCloudTableClient();

            Table = tableClient.GetTableReference(tableName);
            Table.CreateIfNotExists();
        }

        public virtual string Insert(T entity)
        {
            var operation = TableOperation.Insert(entity);
            var result = Table.Execute(operation);
            return result.Etag;
        }

        // update, merge, delete, insert many ...

        protected CloudTable Table;
    }
}