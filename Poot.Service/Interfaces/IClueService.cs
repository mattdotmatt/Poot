using Poot.Models;

namespace Poot.Service.Interfaces
{
    public interface IClueService
    {
        Clue ClueWithId(string gameId, string clueId);
    }
}