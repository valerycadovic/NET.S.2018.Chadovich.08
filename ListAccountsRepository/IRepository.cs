namespace ListAccountsRepository
{
    using System.Collections.Generic;
    using BankSystem;

    public interface IRepository
    {
        void Save(BankAccount account);
        BankAccount GetById(string id);
        IEnumerable<BankAccount> GetAll();
    }
}
