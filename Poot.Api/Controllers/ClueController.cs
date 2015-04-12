using System.Web.Http;
using System.Web.Http.Description;

namespace Poot.Api.Controllers
{
    public class ClueController : ApiController
    {

        [HttpGet]
        [Route("game/{gameId:int}/clue/first")]
        [ResponseType(typeof(GetClueResponse))]
        public IHttpActionResult GetFirstClue(int gameId)
        {
            return Ok(new GetClueResponse());
        }
    }

    public class GetClueResponse
    {
    }
}
