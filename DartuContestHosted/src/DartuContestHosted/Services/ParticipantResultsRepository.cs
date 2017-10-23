using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DartuContestHosted.Models;

namespace DartuContestHosted.Services
{
    public class ParticipantResultsRepository : IParticipantResultsRepository
    {
        private ResultsContext _resultsContext;
        public ParticipantResultsRepository(ResultsContext resultContext)
        {
            _resultsContext = resultContext;
        }
        public List<Rezultate> GetResults()
        {
            return _resultsContext.Rezultate.ToList();
        }
    }
}
