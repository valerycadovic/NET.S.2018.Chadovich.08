using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DAL.Interface.DTO
{
    public class AccountDTO : IEntity<string>
    {
        public string IBAN { get; set; }

        public int Bonuses { get; set; }

        public decimal Balance { get; set; }

        public bool IsActive { get; set; }
        
        public HolderDTO Holder { get; set; }

        public TypeSettingsDTO TypeSettings { get; set; }

        string IEntity<string>.Id
        {
            get => IBAN;
            set => IBAN = value;
        }
    }
}
