using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ft.VotingSystem.Backend.Dataaccess
{
    public class Election : EntityBase<Guid>
    {
        #region ctor

        private Election()
        { }

        #endregion Ctor

        #region Properties

        public string Name { get; private set; }

        public List<Candidate> Candidates { get; private set; }

        public List<Vote> Votes { get; private set; }

        #endregion Properties

        #region Methods

        public void AddCandidate(Candidate candidate)
        {
            this.Candidates.Add(candidate);
            this.Modified();
        }

        public void AddVote(Voter voter)
        {
            var vote = Vote.Create(voter);
            this.Votes.Add(vote);

            this.Modified();
        }

        #endregion Methods

        #region Factory

        public static Election CreateNew(string name)
        {
            var ret = new Election
            {
                Name = name
            };

            ret.Created();

            return ret;
        }

        #endregion Factory
    }
}
