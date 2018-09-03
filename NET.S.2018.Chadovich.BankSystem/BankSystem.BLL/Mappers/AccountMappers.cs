using System;
using System.Collections.Generic;
using BankSystem.BLL.Interface.Entities.Accounts;
using BankSystem.DAL.Interface.DTO;

namespace BankSystem.BLL.Mappers
{
    public static class AccountMappers
    {
        public static AccountDTO ToDal(this Account account)
        {
            var holder = new HolderDTO
            {
                Email = account.Holder.Email,
                Name = account.Holder.Name
            };

            var dal_account = new AccountDTO
            {
                Holder = holder,
                Balance = account.Balance,
                Bonuses = account.BonusPoints,
                Number = account.Number,
            };

            holder.Accounts = new List<AccountDTO> {dal_account};
            return dal_account;
        }

        public static Account ToBllAccount(this AccountDTO account)
        {
            throw new NotImplementedException();
        }
    }
}
