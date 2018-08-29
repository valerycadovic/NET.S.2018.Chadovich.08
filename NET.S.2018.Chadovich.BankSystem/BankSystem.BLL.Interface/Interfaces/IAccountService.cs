using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystem.BLL.Interface.Entities;
using BankSystem.BLL.Interface.Entities.Accounts;

namespace BankSystem.BLL.Interface.Interfaces
{
    public interface IAccountService
    {
        void Open(AccountHolder holder);

        void Close(string number);

        void Deposit(string number, decimal amount);

        void Withdraw(string number, decimal amount);

        void Transfer(string senderNumber, string recipientNumber)

        IEnumerable<Account> GetAll(AccountHolder holder);

        Account Get(AccountHolder holder, string number);
    }
}
