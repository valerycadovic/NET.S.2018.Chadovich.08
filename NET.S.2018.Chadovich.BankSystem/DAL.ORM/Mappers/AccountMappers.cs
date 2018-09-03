using System;
using System.Collections.Generic;
using System.Linq;
using BankSystem.DAL.Interface.DTO;
using ORM.Model;

namespace DAL.ORM.Mappers
{
    public static class AccountMappers
    {
        public static Account ToOrmAccount(this AccountDTO accountDto)
        {
            if (accountDto is null)
            {
                throw new ArgumentNullException($"{nameof(accountDto)} is null");
            }

            return new Account
            {
                Balance = accountDto.Balance,
                Bonuses = accountDto.Bonuses,
                Holder = new Holder
                {
                    Email = accountDto.Holder.Email,
                    Accounts = new HashSet<Account>(
                        from account in accountDto.Holder.Accounts
                        select account.ToOrmAccount()),
                    FullName = accountDto.Holder.FullName,
                    IsActive = accountDto.Holder.IsActive,
                    PassportId = accountDto.Holder.PassportId,
                    AccountIBAN = accountDto.IBAN
                },
                IBAN = accountDto.IBAN,
                IsActive = accountDto.IsActive,
                TypeSetting = new TypeSetting
                {
                    Name = accountDto.TypeSettings.Name,
                    Accounts = new HashSet<Account>(
                        from t in accountDto.TypeSettings.Accounts
                        select accountDto.ToOrmAccount()),
                    DepositCost = accountDto.TypeSettings.DepositCost,
                    WithdrawalCost = accountDto.TypeSettings.WithdrawalCost,
                    Id = accountDto.TypeSettings.Id
                },
                HolderId = accountDto.Holder.PassportId,
                TypeSettingsId = accountDto.TypeSettings.Id
            };
        }

        public static AccountDTO ToAccountDto(this Account account)
        {
            if (account is null)
            {
                throw new ArgumentNullException($"{nameof(account)} is null");
            }

            return new AccountDTO
            {
                Holder = new HolderDTO
                {
                    Email = account.Holder.Email,
                    PassportId = account.Holder.PassportId,
                    Accounts = new HashSet<AccountDTO>(
                        from a in account.Holder.Accounts
                        select a.ToAccountDto()),
                    IsActive = account.Holder.IsActive,
                    FullName = account.Holder.FullName
                },
                TypeSettings = new TypeSettingsDTO
                {
                    Name = account.TypeSetting.Name,
                    Id = account.TypeSetting.Id,
                    Accounts = new HashSet<AccountDTO>(
                        from a in account.Holder.Accounts
                        select a.ToAccountDto()),
                    DepositCost = account.TypeSetting.DepositCost,
                    WithdrawalCost = account.TypeSetting.WithdrawalCost
                },
                Bonuses = account.Bonuses,
                Balance = account.Balance,
                IBAN = account.IBAN,
                IsActive = account.IsActive
            };
        }
    }
}
