using DartuContestHosted.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DartuContestHosted.Services
{
    public interface IParticipantResultsRepository
    {
        List<Rezultate> GetResults();
        Rezultate Get(int id);
        Rezultate Add(Rezultate newRezultat);
        void Delete(int id);
        void Delete(Rezultate model);
        void Commit();
    }
}
