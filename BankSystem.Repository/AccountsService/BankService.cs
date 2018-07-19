namespace BankSystem.Service.AccountsService
{
    using System;
    using BankSystem.Accounts.Factories;
    using BankSystem.Core;
    using ListAccountsRepository;

    public sealed class BankService : IService
    {
        public BankService(IRepository repository, IAccountNumberGenerator idGenerator)
        {
            ValidateOnNull(repository, nameof(repository));
            ValidateOnNull(idGenerator, nameof(idGenerator));
            this.IdGenerator = idGenerator;
            this.Repository = repository;
        }

        public IRepository Repository { get; }

        public IAccountNumberGenerator IdGenerator { get; }

        public void OpenAccount(AccountHolder holder, BankAccountFactory factory)
        {
            ValidateOnNull(holder, nameof(holder));
            ValidateOnNull(factory, nameof(factory));

            BankAccount account = factory.Create(holder, this.IdGenerator);

            holder.AddAccount(account);
            this.Repository.Save(account);
        }

        public void CloseAccount(string id)
        {
            var account = this.Repository.GetById(id) ?? throw new InvalidOperationException($"account #{nameof(id)} has been not created yet");
            account.Status = AccountStatus.Closed;
        }

        public void FreezeAccount(string id)
        {
            var account = this.Repository.GetById(id) ?? 
                          throw new InvalidOperationException($"account #{nameof(id)} has been not created yet");
            account.Status = AccountStatus.Frozen;
        }

        public void UnfreezeAccount(string id)
        {
            var account = this.Repository.GetById(id) ?? 
                          throw new InvalidOperationException($"account #{nameof(id)} has been not created yet");
            account.Status = AccountStatus.Open;
        }

        public void Deposit(string id, decimal amount)
        {
            var account = this.Repository.GetById(id) ?? 
                          throw new InvalidOperationException($"account #{nameof(id)} has been not created yet");
            account.Deposit(amount);
        }

        public void Withdraw(string id, decimal amount)
        {
            var account = this.Repository.GetById(id) ?? 
                          throw new InvalidOperationException($"account #{nameof(id)} has been not created yet");
            account.Withdraw(amount);
        }

        private static void ValidateOnNull<T>(T obj, string name) where T : class
        {
            if (obj is null)
            {
                throw new ArgumentNullException($"{name} is null");
            }
        }
    }
}
