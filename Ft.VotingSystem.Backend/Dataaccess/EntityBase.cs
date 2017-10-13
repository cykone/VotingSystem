using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ft.VotingSystem.Backend.Dataaccess
{
    public abstract class EntityBase<TId>
    {
        #region Properties
        
        public TId Id { get; protected set; }

        public DateTimeOffset CreatedOn { get; private set; }

        public DateTimeOffset ModifiedOn { get; private set; }

        #endregion Properties

        protected void Modified()
        {
            this.ModifiedOn = DateTimeOffset.Now;
        }

        protected void Created()
        {
            this.CreatedOn = DateTimeOffset.Now;
        }
    }
}
