namespace BankSystem.DAL.Fake.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Interface.DTO;
    using Interface.Interfaces;

    public class FakeAccountRepository : IAccountRepository
    {
        private readonly ICollection<DalAccount> _accounts;

        public FakeAccountRepository()
        {
            _accounts = new HashSet<DalAccount>
            {
                new DalAccount
                {
                    Balance = 100.00m,
                    Bonuses = 10,
                    DepositBonuses = 5,
                    WithdrawalBonuses = 4,
                    Holder = new DalHolder
                    {
                        Email = "valerachad03@gmail.com",
                        Name = "Valery Chadovich"
                    }
                },

                new DalAccount
                {
                    Balance = 200.00m,
                    Bonuses = 20,
                    DepositBonuses = 10,
                    WithdrawalBonuses = 4,
                    Holder = new DalHolder
                    {
                        Email = "katy.lap99@gmail.com",
                        Name = "Kate Lapotko"
                    }
                },

                new DalAccount
                {
                    Balance = 20.00m,
                    Bonuses = 5,
                    DepositBonuses = 15,
                    WithdrawalBonuses = 6,
                    Holder = new DalHolder
                    {
                        Email = "anton.apanovich@gmail.com",
                        Name = "Anton Apanovich"
                    }
                },

                new DalAccount
                {
                    Balance = 100.50m,
                    Bonuses = 5,
                    DepositBonuses = 4,
                    WithdrawalBonuses = 6,
                    Holder = new DalHolder
                    {
                        Email = "andrej.sozykin@gmail.com",
                        Name = "ALYOSHA Kanunnikov"
                    }
                },

                new DalAccount
                {
                    Balance = 0.01m,
                    Bonuses = 100,
                    DepositBonuses = 100,
                    WithdrawalBonuses = 1,
                    Holder = new DalHolder
                    {
                        Email = "smotrite.ya.uchu.python79@narhoz.ded",
                        Name = "Artur Prazhenik"
                    }
                }
            };
        }
        

        public IEnumerable<DalAccount> GetAll() => _accounts;
        
        public DalAccount GetById(int key) => _accounts.FirstOrDefault(e => e.Id == key);

        public DalAccount GetByPredicate(Expression<Func<DalAccount, bool>> f)
            => _accounts.FirstOrDefault(f.Compile());

        public void Create(DalAccount e)
        {
            if (e == null)
            {
                throw new ArgumentNullException();
            }

            _accounts.Add(e);
        }

        public void Delete(DalAccount e)
        {
            if (e == null)
            {
                throw new ArgumentNullException();
            }

            _accounts.Remove(e);
        }

        public void Update(DalAccount e)
        {
            if (e == null)
            {
                throw new ArgumentNullException();
            }

            var account = _accounts.FirstOrDefault(item => item.Number == e.Number);

            if (account == null)
            {
                throw new InvalidOperationException();
            }

            account = e;
        }
    }
}
