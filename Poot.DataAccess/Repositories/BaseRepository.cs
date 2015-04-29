using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Poot.DAL.Mappings;
using Poot.Models;
using Poot.Service.Interfaces;

namespace Poot.DAL.Repositories
{
    /// <summary>
    /// Azure Table Storage
    /// </summary>
    public abstract class BaseRepository<TModel, TEntity> : IRepository<TModel>
        where TModel : IModel, new()
        where TEntity : ITableEntity, new()
    {
        private readonly CloudTable _table;

        protected abstract string TableName { get; }
        protected abstract string PartitionKey { get; }

        protected BaseRepository()
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
        /// <param name="model"></param>
        public void Add(TModel model)
        {
            // Create the TableOperation that inserts the widget entity.
            var insertOperation = TableOperation.Insert(MapEntity(model));

            // Execute the insert operation.
            _table.Execute(insertOperation);
        }

        /// <summary>
        /// DeleteAll the widget identified by the id from the repository
        /// </summary>
        /// <param name="id"></param>
        public void Delete(string id)
        {
            var deleteOperation = TableOperation.Delete(GetEntity(id));
            _table.Execute(deleteOperation);
        }

        public void DeleteAll()
        {
            // Create the batch operation.
            var batchOperation = new TableBatchOperation();

            foreach (var entity in AllEntities())
            {
                batchOperation.Delete(entity);
            }

            // Execute the batch operation.
            if (batchOperation.Any()) _table.ExecuteBatch(batchOperation);
        }

        /// <summary>
        /// Get the widget defined by the id from the repository
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TModel Get(string id)
        {
            return Mapper.Map<TModel>(GetEntity(id));
        }

        public void Add(IEnumerable<TModel> models)
        {
            // Create the batch operation.
            var batchOperation = new TableBatchOperation();

            foreach (var model in models)
            {
                batchOperation.Insert(MapEntity(model));
            }

            // Execute the batch operation.
            _table.ExecuteBatch(batchOperation);
        }

        private TEntity MapEntity(TModel model)
        {
            var entity = Mapper.Map<TEntity>(model);
            entity = AddEntityData(model, entity);
            return entity;
        }

        /// <summary>
        /// Get all widgets from the repository
        /// </summary> <returns></returns>
        public IList<TModel> GetAll()
        {
            return Mapper.Map<List<TModel>>(AllEntities());
        }

        protected abstract TEntity AddEntityData(TModel model, TEntity entity);

        private List<TEntity> AllEntities()
        {
            var query = new TableQuery<TEntity>();
            var result = _table.ExecuteQuery(query).ToList();
            return result;
        }

        private TEntity GetEntity(string id)
        {
            var retrieveOperation = TableOperation.Retrieve<TEntity>(PartitionKey, id);
            var retrievedResult = _table.Execute(retrieveOperation);
            return (TEntity) retrievedResult.Result;
        }
    }
}