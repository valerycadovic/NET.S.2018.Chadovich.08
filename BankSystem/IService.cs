namespace BankSystem
{
    using BankSystem.Core;

    public interface IService
    {
        void OpenAccount(IAccountNumberGenerator idGenerator, AccountHolder holder);
        void CloseAccount(string id);
        void FreezeAccount(string id);
        void UnfreezeAccount(string id);
        void Deposit(string id, decimal amount);
        void Withdraw(string id, decimal amount);
    }
}
