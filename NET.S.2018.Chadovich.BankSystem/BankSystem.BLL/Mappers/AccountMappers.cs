using System;
using System.Collections.Generic;
using BankSystem.BLL.Interface.Entities.Accounts;
using BankSystem.DAL.Interface.DTO;

namespace BankSystem.BLL.Mappers
{
    public static class AccountMappers
    {
        public static DalAccount ToDal(this Account account)
        {
            var holder = new DalHolder
            {
                Email = account.Holder.Email,
                Name = account.Holder.Name
            };

            var dal_account = new DalAccount
            {
                Holder = holder,
                Balance = account.Balance,
                Bonuses = account.BonusPoints,
                Number = account.Number,
            };

            holder.Accounts = new List<DalAccount> {dal_account};
            return dal_account;
        }

        public static Account ToBllAccount(this DalAccount account)
        {
            throw new NotImplementedException();
        }
    }
}
