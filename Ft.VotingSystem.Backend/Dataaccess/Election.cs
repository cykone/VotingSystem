using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ft.VotingSystem.Backend.Services;

namespace Ft.VotingSystem.Backend.Dataaccess
{
    public class Election : EntityBase<Guid>
    {
        #region ctor

        private Election()
        {
            this.Candidates = new List<Candidate>();
            this.Votes = new List<Vote>();
        }

        #endregion Ctor

        #region Properties

        public string Title { get; private set; }

        public string Description { get; private set; }

        public List<Candidate> Candidates { get; private set; }

        public List<Vote> Votes { get; private set; }

        #endregion Properties

        #region Methods

        public bool CanVote(string code)
        {
            var vote = this.Votes.SingleOrDefault(v => v.Code == code);
            if (vote == null)
            {
                throw new KeyNotFoundException("Could not find vote with code: " + code);
            }

            // TODO is expired.

            return vote.VotedFor == null;
        }

        public void MakeAVote(string code, Guid candidateId)
        {
            if (!this.CanVote(code))
            {
                throw new InvalidOperationException("Can not vote twice. Check CanVote() before making a vote.");
            }

            var candidate = this.Candidates.SingleOrDefault(c => c.Id == candidateId);
            if (candidate == null)
            {
                throw new KeyNotFoundException("Could not find candidate with id:" + candidateId);
            }

            var vote = this.Votes.SingleOrDefault(v => v.Code == code);
            if (vote == null)
            {
                throw new KeyNotFoundException("Could not find vote with code: " + code);
            }

            vote.VoteFor(candidate);
            this.Modified();
        }

        public void AddCandidate(Candidate candidate)
        {
            this.Candidates.Add(candidate);
            this.Modified();
        }

        public void AddVote(Voter voter, ICodeGenerator codeGenerator)
        {
            var code = string.Empty;
            do
            {
                code = codeGenerator.GenerateUniqueCode(6);
            }
            while (this.Votes.Any(v => v.Code == code));

            var vote = Vote.Create(voter, code);
            this.Votes.Add(vote);

            this.Modified();
        }

        #endregion Methods

        #region Factory

        public static Election CreateNew(string name, string description)
        {
            var ret = new Election
            {
                Title = name,
                Description = description
            };

            ret.Created();

            return ret;
        }

        #endregion Factory
    }
}
