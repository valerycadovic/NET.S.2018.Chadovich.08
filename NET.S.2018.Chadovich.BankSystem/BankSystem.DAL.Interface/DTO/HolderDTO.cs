using System.Collections.Generic;

namespace BankSystem.DAL.Interface.DTO
{
    public class DalHolder : IEntity
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Email { get; set; }

        public IEnumerable<DalAccount> Accounts { get; set; }
    }
}
