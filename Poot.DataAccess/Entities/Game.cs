using Microsoft.WindowsAzure.Storage.Table;

namespace Poot.DAL.Entities
{
    /// <summary>
    /// A game
    /// </summary>
    public class Game : TableEntity
    {
        public string Name { get; set; }
    }
}