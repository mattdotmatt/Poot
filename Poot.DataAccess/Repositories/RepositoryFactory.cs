using Poot.Models;
using Poot.Service.Interfaces;

namespace Poot.DAL.Repositories
{
    /// <summary>
    /// Azure Table Storage
    /// </summary>
    public class RepositoryFactory : IRepositoryFactory
    {
        public IRepository<TModel> Repository<TModel>(params string[] config)
        {
            if (typeof (TModel) == typeof (Clue))
            {
                return (IRepository<TModel>)new ClueRepository(config);
            }
            if (typeof (TModel) == typeof (Game))
            {
                return (IRepository<TModel>)new GameRepository();
            }
            return null;
        }
    }
}