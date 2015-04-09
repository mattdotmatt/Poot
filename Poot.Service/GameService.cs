using Poot.DataAccess.Interfaces;
using Poot.Models;
using Poot.Service.Interfaces;

namespace Poot.Service
{
    public class GameService : IGameService
    {
        private readonly IRepository<Game> _gameRepository;

        public GameService(IRepository<Game> gameRepository )
        {
            _gameRepository = gameRepository;
        }

        public void CreateNewGame(Game activeGame)
        {
            throw new System.NotImplementedException();
        }
    }
}