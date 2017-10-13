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

        public string Firstname { get; private set; }

        public string Lastname { get; private set; }

        public string Email { get; private set; }

        #endregion Properties

        #region Factory

        public static Voter Create(string firstname, string lastname, string email)
        {
            var ret = new Voter
            {
                Firstname = firstname,
                Lastname = lastname,
                Email = email
            };

            ret.Created();

            return ret;
        }

        #endregion Factory
    }
}
