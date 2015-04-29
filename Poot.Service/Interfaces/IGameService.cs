using System.Collections.Generic;
using Poot.Models;

namespace Poot.Service.Interfaces
{
    public interface IGameService
    {
        void CreateNewGame(Game activeGame);
        Game GameWithId(string gameId);
        void Delete(string gameId);
        IList<Game> GetAll();
    }
}