namespace BankSystem.DAL.Fake.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Interface.DTO;
    using Interface.Interfaces;

    public class FakeHolderRepository : IHolderRepository
    {
        private readonly ICollection<DalHolder> _holders;

        public FakeHolderRepository()
        {
            _holders = new HashSet<DalHolder>
            {
                new DalHolder
                {
                    Id = 0,
                    Email = "valerachad03@gmail.com",
                    Name = "Valery Chadovich",
                    Accounts = new HashSet<DalAccount>
                    {
                        new DalAccount
                        {
                            Balance = 100.00m,
                            Bonuses = 100,
                            DepositBonuses = 100,
                            Id = 0
                        }
                    }
                },
                new DalHolder
                {
                    Id = 0,
                    Email = "valerachad04@gmail.com",
                    Name = "Valery Cadovic",
                    Accounts = new HashSet<DalAccount>
                    {
                        new DalAccount
                        {
                            Balance = 10000.00m,
                            Bonuses = 1000,
                            DepositBonuses = 100,
                            WithdrawalBonuses = 100,
                            Id = 1
                        }
                    }
                }
            };
        }

        public IEnumerable<DalHolder> GetAll() => _holders;

        public DalHolder GetById(int key) => _holders.FirstOrDefault(h => h.Id == key);

        public DalHolder GetByPredicate(Expression<Func<DalHolder, bool>> f) => _holders.FirstOrDefault(f.Compile());

        public void Create(DalHolder e)
        {
            if (e == null)
            {
                throw new ArgumentNullException();
            }

            _holders.Add(e);
        }
        
        public void Delete(DalHolder e)
        {
            if (e == null)
            {
                throw new ArgumentNullException();
            }

            _holders.Remove(e);
        }

        public void Update(DalHolder e)
        {
            if (e == null)
            {
                throw new ArgumentNullException();
            }

            var holder = _holders.FirstOrDefault(item => item.Id == e.Id);

            if (holder == null)
            {
                throw new InvalidOperationException();
            }

            holder = e;
        }
    }
}
