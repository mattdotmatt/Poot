using Poot.Models;
using Poot.Service.Interfaces;

namespace Poot.Service
{
    public class ClueService : IClueService
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public ClueService(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public Clue ClueWithId(string gameId, string clueId)
        {
            var clueRepository = _repositoryFactory.Repository<Clue>(gameId);
            return clueRepository.Get(clueId);
        }
    }
}