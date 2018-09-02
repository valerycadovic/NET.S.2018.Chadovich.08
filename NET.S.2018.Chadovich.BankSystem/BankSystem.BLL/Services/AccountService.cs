using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystem.BLL.Interface.Entities;
using BankSystem.BLL.Interface.Entities.Accounts;
using BankSystem.BLL.Interface.Interfaces;

namespace BankSystem.BLL.Services
{
    public class AccountService : IAccountService
    {
        public void Open(AccountHolder holder)
        {
            throw new NotImplementedException();
        }

        public void Close(string number)
        {
            throw new NotImplementedException();
        }

        public void Deposit(string number, decimal amount)
        {
            throw new NotImplementedException();
        }

        public void Withdraw(string number, decimal amount)
        {
            throw new NotImplementedException();
        }

        public void Transfer(string senderNumber, string recipientNumber, decimal amount)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Account> GetAll(AccountHolder holder)
        {
            throw new NotImplementedException();
        }

        public Account Get(AccountHolder holder, string number)
        {
            throw new NotImplementedException();
        }
    }
}
