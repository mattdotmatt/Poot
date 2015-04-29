using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using Poot.Models;
using Poot.Service;

namespace Poot.Api.Controllers
{
    public class ClueController : ApiController
    {
        private readonly ClueService _clueService;

        public ClueController(ClueService clueService)
        {
            _clueService = clueService;
        }

        [HttpGet]
        [Route("game/{gameId:string}/clue/first")]
        [ResponseType(typeof (Clue))]
        public IHttpActionResult GetFirstClue(string gameId)
        {
            var game = _clueService.ClueWithId(gameId, "Clue_1");
            return Ok(game);
        }

        [HttpGet]
        [Route("game/{gameId:string}/clue/second")]
        [ResponseType(typeof(Clue))]
        public IHttpActionResult GetSecondClue(string gameId)
        {
            var game = _clueService.ClueWithId(gameId, "Clue_2");
            return Ok(game);
        }
    }
}