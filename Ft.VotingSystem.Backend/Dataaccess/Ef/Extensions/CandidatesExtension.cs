using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ft.VotingSystem.Backend.ViewModel;

namespace Ft.VotingSystem.Backend.Dataaccess.Ef.Extensions
{
    public static class CandidatesExtension
    {
        public static CandidateViewModel ToViewModel(this Candidate candidate)
        {
            var ret = new CandidateViewModel
            {
                Id = candidate.Id.ToString(),
                Name = candidate.Name
            };

            return ret;
        }

    }
}
