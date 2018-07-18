namespace ListAccountsRepository
{
    using System;
    using System.Collections.Generic;
    using BankSystem;

    public class ListRepository : IRepository
    {
        private List<BankAccount> accounts = new List<BankAccount>();

        public void Save(BankAccount account, string id)
        {
            if (account is null)
            {
                throw new ArgumentNullException($"{nameof(account)} is null");
            }

            BankAccount current = null;
            
            foreach (var item in this.accounts)
            {
                if (item.Id == id)
                {
                    current = item;
                    break;
                }
            }

            if (current is null)
            {
                this.accounts.Add(account);
                return;
            }

            current = account;
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
