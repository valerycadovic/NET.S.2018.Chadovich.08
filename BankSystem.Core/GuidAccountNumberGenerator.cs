using System;

namespace BankSystem.Core
{
    public class GuidAccountNumberGenerator : IAccountNumberGenerator
    {
        public string GenerateAccountNumber() => Guid.NewGuid().ToString("N");
    }
}
