using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystem.Core;

namespace BankSystem.Accounts.Factories
{
    public abstract class BankAccountFactory
    {
        public abstract BankAccount Create(
            AccountHolder holder,
            IAccountNumberGenerator idGenerator,
            IMoneyAccuracyCalculator moneyRounder = null);
    }
}
