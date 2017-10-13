using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ft.VotingSystem.Backend.Dataaccess.Ef;
using Ft.VotingSystem.Backend.Dataaccess.Ef.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ft.VotingSystem.Backend.Controllers
{
    [Route("api/[controller]")]
    public class ElectionsController : Controller
    {
        #region Fields

        private readonly ElectionDbContext context;

        #endregion Fields

        #region Ctor

        public ElectionsController(ElectionDbContext context)
        {
            this.context = context;
        }

        #endregion Ctor

        #region Election

        [HttpGet]
        public async Task<IActionResult> GetElections()
        {
            var elections = this.context.Elections.Select(e => e.ToViewModel());
            return new ObjectResult(elections);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync()
        {
            return await Task.FromResult(new OkResult());
        }

        #endregion Election

        #region Candidates

        [HttpGet("{electionId}/candidates")]
        public async Task<IActionResult> GetCandidatesForElectionId(string electionId)
        {
            var election = await this.context.Elections
                                .Include(e => e.Candidates)
                                .SingleOrDefaultAsync(e => e.Id == Guid.Parse(electionId));

            if (election == null)
            {
                return new NotFoundResult();
            }

            var candidates = election.Candidates.Select(c => c.ToViewModel());

            return new ObjectResult(candidates);
        }

        #endregion Candidates

        #region Vote

        [HttpPost("{electionId}/vote/{candidateId}")]
        public async Task<IActionResult> Vote(string electionId, string candidateId, [FromBody] string code)
        {

            var election = await this.context.Elections
                                             .Include(e => e.Votes)
                                                .ThenInclude(v => v.VotedFor)
                                             .Include(e => e.Votes)
                                             .Include(e => e.Candidates)
                                             .SingleOrDefaultAsync(e => e.Id == Guid.Parse(electionId));
            if (election == null)
            {
                return new NotFoundResult();
            }

            if(!election.CanVote(code))
            {
                return new UnauthorizedResult();
            }

            election.MakeAVote(code, Guid.Parse(candidateId));
            await this.context.SaveChangesAsync();


            return new OkResult();
        }

        #endregion Vote
    }
}
