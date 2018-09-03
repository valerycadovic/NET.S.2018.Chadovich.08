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
        private readonly ICollection<AccountDTO> _accounts;

        public FakeAccountRepository()
        {
            _accounts = new HashSet<AccountDTO>
            {
                new AccountDTO
                {
                    Balance = 100.00m,
                    Bonuses = 10,
                    DepositBonuses = 5,
                    WithdrawalBonuses = 4,
                    Holder = new HolderDTO
                    {
                        Email = "valerachad03@gmail.com",
                        Name = "Valery Chadovich"
                    }
                },

                new AccountDTO
                {
                    Balance = 200.00m,
                    Bonuses = 20,
                    DepositBonuses = 10,
                    WithdrawalBonuses = 4,
                    Holder = new HolderDTO
                    {
                        Email = "katy.lap99@gmail.com",
                        Name = "Kate Lapotko"
                    }
                },

                new AccountDTO
                {
                    Balance = 20.00m,
                    Bonuses = 5,
                    DepositBonuses = 15,
                    WithdrawalBonuses = 6,
                    Holder = new HolderDTO
                    {
                        Email = "anton.apanovich@gmail.com",
                        Name = "Anton Apanovich"
                    }
                },

                new AccountDTO
                {
                    Balance = 100.50m,
                    Bonuses = 5,
                    DepositBonuses = 4,
                    WithdrawalBonuses = 6,
                    Holder = new HolderDTO
                    {
                        Email = "andrej.sozykin@gmail.com",
                        Name = "ALYOSHA Kanunnikov"
                    }
                },

                new AccountDTO
                {
                    Balance = 0.01m,
                    Bonuses = 100,
                    DepositBonuses = 100,
                    WithdrawalBonuses = 1,
                    Holder = new HolderDTO
                    {
                        Email = "smotrite.ya.uchu.python79@narhoz.ded",
                        Name = "Artur Prazhenik"
                    }
                }
            };
        }
        

        public IEnumerable<AccountDTO> GetAll() => _accounts;
        
        public AccountDTO GetById(int key) => _accounts.FirstOrDefault(e => e.Id == key);

        public AccountDTO GetByPredicate(Expression<Func<AccountDTO, bool>> f)
            => _accounts.FirstOrDefault(f.Compile());

        public void Create(AccountDTO e)
        {
            if (e == null)
            {
                throw new ArgumentNullException();
            }

            _accounts.Add(e);
        }

        public void Delete(AccountDTO e)
        {
            if (e == null)
            {
                throw new ArgumentNullException();
            }

            _accounts.Remove(e);
        }

        public void Update(AccountDTO e)
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
