using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystem.DAL.Interface.Interfaces;

namespace DAL.ORM
{
    public class OrmUnitOfWork: IUnitOfWork
    {

        public void Commit()
        {
            
        }

        public void Dispose()
        {
        }
    }
}
