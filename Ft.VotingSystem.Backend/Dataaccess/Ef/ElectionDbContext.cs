using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ft.VotingSystem.Backend.Dataaccess.Ef.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Ft.VotingSystem.Backend.Dataaccess.Ef
{
    public class ElectionDbContext : DbContext
    {
        #region Fields

        
        #endregion Fields

        #region Ctor

        public ElectionDbContext(DbContextOptions<ElectionDbContext> options) : base(options)
        {}

        #endregion Ctor

        #region Properties

        public DbSet<Candidate> Candidates { get; set; }

        public DbSet<Vote> Votes { get; set; }

        public DbSet<Election> Elections { get; set; }

        public DbSet<Voter> Voters { get; set; }

        #endregion Properties

        #region Methods
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ElectionConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        #endregion Methods
    }
}
