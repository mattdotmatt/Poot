using System.Collections.Generic;

namespace Poot.Models
{
    public class Game
    {
        public List<Clue> Clues { get; set; }

        public Game(List<Clue> clues)
        {
            Clues = clues;
        }
    }
}