using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DAL.Interface.DTO
{
    public class TypeSettingsDTO : IEntity<int>
    {
        public int Id { get; set; }

        public int WithdrawalCost { get; set; }

        public int DepositCost { get; set; }

        public string Name { get; set; }

        public IEnumerable<AccountDTO> Accounts { get; set; }
    }
}
