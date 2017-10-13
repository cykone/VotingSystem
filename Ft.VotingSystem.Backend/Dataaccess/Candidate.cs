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

        public string Name { get; protected set; }

        public string Email { get; protected set; }

        #endregion Properties

        #region Factory

        public static Candidate CreateNew(string name, string email)
        {
            var ret = new Candidate
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
