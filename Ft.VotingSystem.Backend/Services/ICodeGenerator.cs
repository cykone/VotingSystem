using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ft.VotingSystem.Backend.Services
{
    public interface ICodeGenerator
    {
        string GenerateUniqueCode(int length);
    }
}
