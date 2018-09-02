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
        public IEnumerable<DalAccount> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalAccount GetById(int key)
        {
            throw new NotImplementedException();
        }

        public DalAccount GetByPredicate(Expression<Func<DalAccount, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(DalAccount e)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalAccount e)
        {
            throw new NotImplementedException();
        }

        public void Update(DalAccount e)
        {
            throw new NotImplementedException();
        }
    }
}
