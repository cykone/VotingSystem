using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ft.VotingSystem.Backend.Dataaccess
{
    public class Voter : EntityBase<Guid>
    {
        #region Ctor

        private Voter()
        {}

        #endregion Ctor

        #region Properties

        public string Name { get; private set; }

        public string Email { get; private set; }

        #endregion Properties

        #region Factory

        public static Voter Create(string name, string email)
        {
            var ret = new Voter
            {
                Name = name,
                Email = email
            };

            ret.Created();

            return ret;
        }

        #endregion Factory
    }
}
