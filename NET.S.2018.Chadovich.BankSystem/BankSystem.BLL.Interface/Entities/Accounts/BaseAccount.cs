using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystem.BLL.Interface.Interfaces;

namespace BankSystem.BLL.Interface.Entities.Accounts
{
    public sealed class BaseAccount : Account
    {
        public BaseAccount(string number, AccountHolder holder, IBonusCalculator scorer, AccountStatus status) 
            : base(number, holder, scorer, status)
        {
        }

        protected override void DepositBalance(decimal amount)
        {
            this.Balance += amount;
        }

        protected override void WithdrawBalance(decimal amount)
        {
            this.Balance -= amount;
        }
    }
}
