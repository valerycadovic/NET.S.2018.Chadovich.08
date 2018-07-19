using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystem;

namespace ListAccountsRepository
{
    public interface IHoldersRepository
    {
        void SaveHolder(AccountHolder holder);
        AccountHolder GetHolder(string name, string email, string phone);
        IEnumerable<AccountHolder> GelAll();
    }
}
