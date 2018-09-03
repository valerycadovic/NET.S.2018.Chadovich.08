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
        public IEnumerable<HolderDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public HolderDTO GetById(int key)
        {
            throw new NotImplementedException();
        }
        
        public HolderDTO GetByPredicate(Expression<Func<HolderDTO, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(HolderDTO e)
        {
            throw new NotImplementedException();
        }

        public void Delete(HolderDTO e)
        {
            throw new NotImplementedException();
        }

        public void Update(HolderDTO e)
        {
            throw new NotImplementedException();
        }
    }
}
