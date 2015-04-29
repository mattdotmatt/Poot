using System.Collections.Generic;

namespace Poot.Models
{
    public class Game : IModel
    {
        public IList<Clue> Clues { get; private set; }
        public string Name { get; private set; }
        public string ETag { get; private set; }

        public Game(string name, IList<Clue> clues)
        {
            Name = name;
            Clues = clues;
        }

        public Game(){}
    }
}