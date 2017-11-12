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

        public Rezultate Add(Rezultate newRezultat)
        {
            _resultsContext.Add(newRezultat);
            return newRezultat;
        }

        public Rezultate Get(int id)
        {
            return _resultsContext.Rezultate.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Commit()
        {
            _resultsContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = _resultsContext.Rezultate.Where(x => x.Id == id).FirstOrDefault();
            if(model != null)
            {
                _resultsContext.Rezultate.Remove(model);
            }
        }
        
        public void Delete(Rezultate model)
        {
            _resultsContext.Rezultate.Remove(model);
        }
        
    }
}
