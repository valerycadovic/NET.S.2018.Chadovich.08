using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystem.Core;

namespace BankSystem
{
    public sealed class BankService : IService
    {

        public void OpenAccount(IAccountNumberGenerator idGenerator, AccountHolder holder)
        {
            // account abstract factory
            throw new NotImplementedException();
        }

        public void CloseAccount(string id)
        {
            throw new NotImplementedException();
        }

        public void FreezeAccount(string id)
        {
            throw new NotImplementedException();
        }

        public void UnfreezeAccount(string id)
        {
            throw new NotImplementedException();
        }

        public void Deposit(string id, decimal amount)
        {
            throw new NotImplementedException();
        }

        public void Withdraw(string id, decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
