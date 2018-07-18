namespace BankSystem
{
    using BankSystem.Core;

    public interface IService
    {
        void OpenAccount(IAccountNumberGenerator idGenerator, AccountHolder holder);
    }
}
