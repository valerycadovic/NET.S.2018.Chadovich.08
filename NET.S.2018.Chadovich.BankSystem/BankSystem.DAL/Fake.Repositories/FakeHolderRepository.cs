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
        private readonly ICollection<HolderDTO> _holders;

        public FakeHolderRepository()
        {
            _holders = new HashSet<HolderDTO>
            {
                new HolderDTO
                {
                    Id = 0,
                    Email = "valerachad03@gmail.com",
                    Name = "Valery Chadovich",
                    Accounts = new HashSet<AccountDTO>
                    {
                        new AccountDTO
                        {
                            Balance = 100.00m,
                            Bonuses = 100,
                            DepositBonuses = 100,
                            Id = 0
                        }
                    }
                },
                new HolderDTO
                {
                    Id = 0,
                    Email = "valerachad04@gmail.com",
                    Name = "Valery Cadovic",
                    Accounts = new HashSet<AccountDTO>
                    {
                        new AccountDTO
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

        public IEnumerable<HolderDTO> GetAll() => _holders;

        public HolderDTO GetById(int key) => _holders.FirstOrDefault(h => h.Id == key);

        public HolderDTO GetByPredicate(Expression<Func<HolderDTO, bool>> f) => _holders.FirstOrDefault(f.Compile());

        public void Create(HolderDTO e)
        {
            if (e == null)
            {
                throw new ArgumentNullException();
            }

            _holders.Add(e);
        }
        
        public void Delete(HolderDTO e)
        {
            if (e == null)
            {
                throw new ArgumentNullException();
            }

            _holders.Remove(e);
        }

        public void Update(HolderDTO e)
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
