using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ft.VotingSystem.Backend.Services;

namespace Ft.VotingSystem.Backend.Dataaccess.Ef
{
    public class DbSeeder
    {
        #region Fields

        private readonly ICodeGenerator codeGenerator;
        private readonly ElectionDbContext context;

        #endregion Fields

        #region Ctor

        public DbSeeder(ICodeGenerator codeGenerator, ElectionDbContext context)
        {
            this.codeGenerator = codeGenerator;
            this.context = context;
        }

        #endregion Ctor


        public void Initialize()
        {
            if (this.context.Elections.Count() > 0)
            {
                return;
            }

            var studentRepElection = Election.CreateNew("Student Representative Election 2017", "The RCA Service Design MA2 are electing a new student representative. This election excepts votes till 6pm.");

            //Candidates
            var testCandidate1 = Candidate.CreateNew("Test", "Candidate 1", "florian.tiefenbach@network.rca.ac.uk");
            studentRepElection.AddCandidate(testCandidate1);

            var testCandidate2 = Candidate.CreateNew("Test", "Candidate 2", "florian.tiefenbach@network.rca.ac.uk");
            studentRepElection.AddCandidate(testCandidate2);

            var testCandidate3 = Candidate.CreateNew("Test", "Candidate 3", "florian.tiefenbach@network.rca.ac.uk");
            studentRepElection.AddCandidate(testCandidate3);

            // Voters
            var voter1 = Voter.Create("Florian", "Tiefenbach", "florian.tiefenbach@network.rca.ac.uk");
            studentRepElection.AddVote(voter1, this.codeGenerator);

            var voter2 = Voter.Create("Test", "Voter 1", "florian.tiefenbach@network.rca.ac.uk");
            studentRepElection.AddVote(voter2, this.codeGenerator);

            var voter3 = Voter.Create("Test", "Voter 2", "florian.tiefenbach@network.rca.ac.uk");
            studentRepElection.AddVote(voter3, this.codeGenerator);

            this.context.Elections.Add(studentRepElection);
            this.context.SaveChanges();
        }
    }
}
