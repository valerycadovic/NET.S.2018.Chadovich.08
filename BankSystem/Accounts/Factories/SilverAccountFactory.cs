using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystem.Core;

namespace BankSystem.Accounts.Factories
{
    public class SilverAccountFactory : BankAccountFactory
    {
        public override BankAccount Create(AccountHolder holder, IAccountNumberGenerator idGenerator,
            IMoneyAccuracyCalculator moneyRounder = null)
        {
            return new SilverAccount(holder, idGenerator, moneyRounder);
        }
    }
}
