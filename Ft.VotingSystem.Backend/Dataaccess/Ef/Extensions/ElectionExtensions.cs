using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ft.VotingSystem.Backend.ViewModel;

namespace Ft.VotingSystem.Backend.Dataaccess.Ef.Extensions
{
    public static class ElectionExtensions
    {
        public static ElectionViewModel ToViewModel(this Election election)
        {
            var ret = new ElectionViewModel
            {
                Id = election.Id.ToString(),
                Title = election.Title,
                Description = election.Description
            };

            return ret;
        }
    }
}
