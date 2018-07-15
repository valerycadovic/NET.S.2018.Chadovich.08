using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public interface IAccount
    {
        Client Owner { get; }
        void Deposit(decimal amount);
        void Withdraw(decimal amount);
    }
}
