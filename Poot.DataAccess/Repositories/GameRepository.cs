using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Poot.DAL.Entities;
using Poot.DAL.Mappings;
using Poot.Service.Interfaces;

namespace Poot.DAL.Repositories
{
    /// <summary>
    /// Azure Table Storage flavour of widget repository
    /// </summary>
    public class GameRepository : IRepository<Models.Game>
    {
        private readonly CloudTable _table;
        private const string TableName = "widget";
        private const string PartitionKey = "WIDGET";

        public GameRepository()
        {
            AutoMapperBootstrapper.InitMappings();
            var storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
            var tableClient = storageAccount.CreateCloudTableClient();
            _table = tableClient.GetTableReference(TableName);
            _table.CreateIfNotExists();
        }

        /// <summary>
        /// Add the supplied widget to the repository
        /// </summary>
        /// <param name="widget"></param>
        public void Add(Models.Game game)
        {
            var widgetEntity = Mapper.Map<Game>(game);
            widgetEntity.PartitionKey = PartitionKey;
            widgetEntity.RowKey = game.Name;

            // Create the TableOperation that inserts the widget entity.
            var insertOperation = TableOperation.Insert(widgetEntity);

            // Execute the insert operation.
            _table.Execute(insertOperation);
        }

        /// <summary>
        /// Delete the widget identified by the id from the repository
        /// </summary>
        /// <param name="id"></param>
        public void Delete(string id)
        {
            var widgetToDelete = GetGame(id);
            var deleteOperation = TableOperation.Delete(widgetToDelete);
            _table.Execute(deleteOperation);
        }

        /// <summary>
        /// Get the widget defined by the id from the repository
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Models.Game Get(string id)
        {
            return Mapper.Map<Models.Game>(GetGame(id));
        }

        /// <summary>
        /// Get all widgets from the repository
        /// </summary>
        /// <returns></returns>
        public IList<Models.Game> GetAll()
        {
            var query = new TableQuery<Game>();
            var result = _table.ExecuteQuery(query).ToList();
            return Mapper.Map<List<Models.Game>>(result);
        }

        private Game GetGame(string id)
        {
            var retrieveOperation = TableOperation.Retrieve<Game>(PartitionKey, id);
            var retrievedResult = _table.Execute(retrieveOperation);
            return (Game) retrievedResult.Result;
        }
    }
}