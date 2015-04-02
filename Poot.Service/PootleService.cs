using System;
using System.Collections.Generic;
using Poot.AzureStorage;
using Pootle = Poot.Models.Pootle;

namespace Poot.Service
{
    public class PootleService
    {
        private readonly IRepository<Pootle> _pootleRepository;

        public PootleService(IRepository<Models.Pootle> pootleRepository)
        {
            _pootleRepository = pootleRepository;
        }

        public IEnumerable<Models.Pootle> GetAllPoots()
        {
            var pootles = new List<Models.Pootle>();
            //var storage = new PootleStorage();
            //var poots = storage.GetAll();
            //return pootles;
            _pootleRepository.GetAll();
            return pootles;
        } 
    }

    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
    }
}
