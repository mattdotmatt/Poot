using System.Web.Http;
using System.Web.Http.Description;
using Poot.Models;
using Poot.Service;

namespace Poot.Api.Controllers
{
    public class GameController : ApiController
    {
        private readonly GameService _gameService;

        public GameController(GameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        [Route("game/{gameId:string}")]
        [ResponseType(typeof (Game))]
        public IHttpActionResult GetGame(string gameId)
        {
            var game = _gameService.GameWithId(gameId);
            return Ok(game);
        }
    }
}
