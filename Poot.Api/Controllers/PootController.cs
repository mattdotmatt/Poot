using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Poot.Models;
using Poot.Service;

namespace Poot.Api.Controllers
{
    public class PootController : ApiController
    {
        public string x()
        {
            var pootleRepository = new Repository<Pootle>();
            var pootleService = new PootleService(pootleRepository);
            pootleService.GetAllPoots();
            return "";
        }
    }

    public class Repository<T> : IRepository<Pootle>
    {
        public IEnumerable<Pootle> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
