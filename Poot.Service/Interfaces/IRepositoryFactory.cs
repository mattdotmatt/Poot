namespace Poot.Service.Interfaces
{
    public interface IRepositoryFactory
    {
        IRepository<TModel> Repository<TModel>(params string[] config);
    }
}