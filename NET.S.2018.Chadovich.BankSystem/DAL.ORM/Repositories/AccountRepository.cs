using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BankSystem.DAL.Interface.DTO;
using BankSystem.DAL.Interface.Interfaces;

namespace DAL.ORM.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public IEnumerable<AccountDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public AccountDTO GetById(int key)
        {
            throw new NotImplementedException();
        }

        public AccountDTO GetByPredicate(Expression<Func<AccountDTO, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(AccountDTO e)
        {
            throw new NotImplementedException();
        }

        public void Delete(AccountDTO e)
        {
            throw new NotImplementedException();
        }

        public void Update(AccountDTO e)
        {
            throw new NotImplementedException();
        }
    }
}
