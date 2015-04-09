namespace Poot.Models
{
    public class Clue
    {
        public int ClueNumber { get; set; }
        public string Glyph { get; set; }

        public Clue(int clueNumber, string glyph)
        {
            ClueNumber = clueNumber;
            Glyph = glyph;
        }
    }
}