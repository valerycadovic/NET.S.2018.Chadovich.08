namespace ListAccountsRepository
{
    using System;
    using System.Collections.Generic;
    using BankSystem;

    public class ListRepository : IRepository
    {
        private HashSet<BankAccount> accounts = new HashSet<BankAccount>();

        public void Save(BankAccount account, string id)
        {
            if (account is null)
            {
                throw new ArgumentNullException($"{nameof(account)} is null");
            }

            if (!accounts.Contains(account))
            {
                accounts.Add(account);
            }
        }

        public BankAccount GetById(string id)
        {
            foreach (var item in accounts)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }

            return null;
        }
    }
}
