namespace ListAccountsRepository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using BankSystem;

    public class ListHoldersRepository : IHoldersRepository
    {
        private HashSet<AccountHolder> holders = new HashSet<AccountHolder>();

        private static readonly Lazy<ListHoldersRepository> LazyInstance =
            new Lazy<ListHoldersRepository>(() => new ListHoldersRepository(), LazyThreadSafetyMode.ExecutionAndPublication);
        

        public static IHoldersRepository Instance = LazyInstance.Value;

        private ListHoldersRepository()
        {
        }

        public void SaveHolder(AccountHolder holder)
        {
            if (holder is null)
            {
                throw new ArgumentNullException($"{nameof(holder)} is null");
            }

            holders.Add(holder);
        }

        public AccountHolder GetHolder(string name, string email, string phone)
        {
            var holder = new AccountHolder(name, email, phone);

            return holders.FirstOrDefault(h => h.Equals(holder));
        }
        
        public IEnumerable<AccountHolder> GelAll()
        {
            return holders.ToList();
        }
    }
}
