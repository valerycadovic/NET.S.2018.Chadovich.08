using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DAL.Interface.DTO
{
    public class DalAccount : IEntity
    {
        public int Id { get; set; }
        
        public string Number { get; set; }

        public DalHolder Holder { get; set; }

        public decimal Balance { get; set; }

        public int Bonuses { get; set; }

        public int WithdrawalBonuses { get; set; }

        public int DepositBonuses { get; set; }
    }
}
