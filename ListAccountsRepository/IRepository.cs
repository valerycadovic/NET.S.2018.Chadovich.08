using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystem;

namespace ListAccountsRepository
{
    public interface IRepository
    {
        void Save(BankAccount account, string id);
        BankAccount GetById(string id);
    }
}
