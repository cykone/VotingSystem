using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ft.VotingSystem.Backend.Dataaccess
{
    public class Candidate : EntityBase<Guid>
    {
        #region Ctor

        private Candidate()
        { }

        #endregion Ctor

        #region Properties

        public string Firstname { get; protected set; }

        public string Lastname { get; protected set; }

        public string Email { get; protected set; }

        public string Name => Firstname + " " + Lastname;

        #endregion Properties

        #region Factory

        public static Candidate CreateNew(string firstname, string lastname, string email)
        {
            var ret = new Candidate
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
