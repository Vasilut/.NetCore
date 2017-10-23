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
    }
}
