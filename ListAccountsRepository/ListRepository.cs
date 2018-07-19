namespace ListAccountsRepository
{
    using System;
    using System.Collections.Generic;
    using BankSystem;
    using System.Linq;
    using System.Threading;

    public class ListRepository : IRepository
    {
        private readonly HashSet<BankAccount> accounts = new HashSet<BankAccount>();

        private static readonly Lazy<ListRepository> LazyInstance = 
            new Lazy<ListRepository>(() => new ListRepository(), LazyThreadSafetyMode.ExecutionAndPublication);

        private ListRepository()
        {
        }

        public static IRepository Instance = LazyInstance.Value;

        public void Save(BankAccount account)
        {
            if (account is null)
            {
                throw new ArgumentNullException($"{nameof(account)} is null");
            }

            accounts.Add(account);
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

        public IEnumerable<BankAccount> GetAll()
        {
            return accounts.ToList();
        }
    }
}
