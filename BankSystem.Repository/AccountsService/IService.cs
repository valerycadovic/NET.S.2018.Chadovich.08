using System.Collections.Generic;

namespace BankSystem.Service.AccountsService
{
    using BankSystem.Core;
    using BankSystem.Accounts.Factories;

    public interface IService
    {
        void OpenAccount(AccountHolder holder, BankAccountFactory factory);
        void CloseAccount(string id);
        void FreezeAccount(string id);
        void UnfreezeAccount(string id);
        void Deposit(string id, decimal amount);
        void Withdraw(string id, decimal amount);
    }
}
