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
    public class HolderRepository : IHolderRepository
    {
        public IEnumerable<DalHolder> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalHolder GetById(int key)
        {
            throw new NotImplementedException();
        }

        public DalHolder GetByPredicate(Expression<Func<DalHolder, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(DalHolder e)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalHolder e)
        {
            throw new NotImplementedException();
        }

        public void Update(DalHolder e)
        {
            throw new NotImplementedException();
        }
    }
}
