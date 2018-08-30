using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DAL.Interface.DTO
{
    public class DalHolder : IEntity
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}
