using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage.Table;

namespace Poot.DAL.Entities
{
    /// <summary>
    /// A game
    /// </summary>
    public class Game : TableEntity
    {
        public string Name { get; set; }
        public List<Clue> Clues { get; private set; }
    }

    public class Clue : TableEntity
    {
        public int ClueNumber { get; set; }
        public string Glyph { get; set; }

        public Clue(int clueNumber, string glyph)
        {
            ClueNumber = clueNumber;
            Glyph = glyph;
        }

        public Clue(){}
    }
}