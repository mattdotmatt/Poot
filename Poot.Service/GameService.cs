using System.Collections.Generic;
using System.Linq;
using Poot.Models;
using Poot.Service.Interfaces;

namespace Poot.Service
{
    public class GameService : IGameService
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public GameService(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public void CreateNewGame(Game activeGame)
        {
            _repositoryFactory.Repository<Game>().Add(activeGame);
            var clueRepository = _repositoryFactory.Repository<Clue>(activeGame.Name);
            clueRepository.Add(activeGame.Clues);
        }

        public Game GameWithId(string gameId)
        {
            return _repositoryFactory.Repository<Game>().Get(gameId);
        }

        public IList<Game> GetAll()
        {
            return _repositoryFactory.Repository<Game>().GetAll();
        }

        public void Delete(string gameId)
        {
            _repositoryFactory.Repository<Game>().Delete(gameId);
        }

        public void DeleteAll()
        {
            foreach (var clueRepository in _repositoryFactory.Repository<Game>().GetAll().Select(game => _repositoryFactory.Repository<Clue>(game.Name)))
            {
                clueRepository.DeleteAll();
            }
            _repositoryFactory.Repository<Game>().DeleteAll();
        }
    }
}