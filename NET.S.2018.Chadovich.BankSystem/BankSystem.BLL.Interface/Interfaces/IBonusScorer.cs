using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystem.BLL.Interface.Entities.Accounts;

namespace BankSystem.BLL.Interface.Interfaces
{
    public interface IBonusScorer
    {
        int GetDepositBonus(Account account, decimal amount);

        int GetWithdrawBonus(Account account, decimal amount);
    }
}
