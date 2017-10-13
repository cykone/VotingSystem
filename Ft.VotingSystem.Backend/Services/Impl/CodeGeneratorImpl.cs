using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Ft.VotingSystem.Backend.Services.Impl
{
    public class CodeGeneratorImpl : ICodeGenerator
    {

        private const string AllowableCharacters = "abcdefghijklmnopqrstuvwxyz0123456789";

        public string GenerateUniqueCode(int length)
        {
            var bytes = new byte[length];

            using (var random = RandomNumberGenerator.Create())
            {
                random.GetBytes(bytes);
            }

            return new string(bytes.Select(x => AllowableCharacters[x % AllowableCharacters.Length]).ToArray());
        }
    }
}
