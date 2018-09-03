using System.Collections.Generic;

namespace BankSystem.DAL.Interface.DTO
{
    public class HolderDTO : IEntity<string>
    {
        public string PassportId { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }

        public IEnumerable<AccountDTO> Accounts { get; set; } = new HashSet<AccountDTO>();

        string IEntity<string>.Id
        {
            get => PassportId;
            set => PassportId = value;
        }
    }
}
