using System;
using System.Collections.Generic;
using System.Linq;
using BankSystem.DAL.Interface.DTO;
using ORM.Model;

namespace DAL.ORM.Mappers
{
    public static class HolderMappers
    {
        public static Holder ToOrmHolder(this HolderDTO holderDto)
        {
            if (holderDto is null)
            {
                throw new ArgumentNullException($"{nameof(holderDto)} is null");
            }

            return new Holder
            {
                Email = holderDto.Email,
                FullName = holderDto.FullName,
                IsActive = holderDto.IsActive,
                PassportId = holderDto.PassportId,
                Accounts = new HashSet<Account>
                (
                    from item in holderDto.Accounts
                    select item.ToOrmAccount()
                )
            };
        }

        public static HolderDTO ToHolderDto(this Holder holder)
        {
            if (holder is null)
            {
                throw new ArgumentNullException($"{nameof(holder)} is null");
            }

            return new HolderDTO
            {
                Email = holder.Email,
                FullName = holder.FullName,
                IsActive = holder.IsActive,
                PassportId = holder.PassportId,
                Accounts = new HashSet<AccountDTO>
                (
                    from item in holder.Accounts
                    select item.ToAccountDto()
                )
            };
        }
    }
}
