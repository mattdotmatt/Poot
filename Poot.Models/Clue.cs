using System.Globalization;

namespace Poot.Models
{
    public class Clue : IModel
    {
        public int ClueNumber { get; set; }
        public string Glyph { get; set; }
        public string Name { get; private set; }
        public string ETag { get; private set; }

        public Clue(int clueNumber, string glyph)
        {
            Name = clueNumber.ToString(CultureInfo.InvariantCulture);
            ClueNumber = clueNumber;
            Glyph = glyph;
        }

        public Clue(){}
    }
}