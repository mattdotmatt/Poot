using System;
using System.Collections.Generic;
using Poot.DataAccess.Interfaces;
using Poot.Models;

namespace Poot.DataAccess.Implementations
{
    public class GameRepository : IRepository<Game>
    {
        public IEnumerable<Game> GetAll()
        {
            throw new NotImplementedException();
        }

        public Game Create(Game game)
        {
            throw new NotImplementedException();
        }
    }
}