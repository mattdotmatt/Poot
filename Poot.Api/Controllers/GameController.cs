using System.Web.Http;
using System.Web.Http.Description;
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
        [Route("game/{gameId:int}")]
        [ResponseType(typeof (GetGameResponse))]
        public IHttpActionResult GetGame(int gameId)
        {
            return Ok(new GetGameResponse());
        }
    }
}
