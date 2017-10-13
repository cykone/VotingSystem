using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ft.VotingSystem.Backend.Dataaccess
{
    public class Vote : EntityBase<Guid>
    {
        #region Ctor

        private Vote()
        { }

        #endregion Ctor

        #region Properties

        public Election Election { get; private set; }

        public Candidate VotedFor { get; private set; }

        public Voter Voter { get; private set; }

        #endregion Properties

        #region Methods

        public void VoteFor(Candidate candidate)
        {
            this.VotedFor = candidate;
            this.Modified();
        }

        #endregion Methods

        #region Factory

        public static Vote Create(Voter voter)
        {
            var ret = new Vote
            {
                Voter = voter
            };

            return ret;
        }

        #endregion Factory
    }
}
