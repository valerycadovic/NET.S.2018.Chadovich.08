using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class BankAccount : IAccount
    {
        private decimal cash;

        public BankAccount(Client owner, IAccountType accountType)
        {
            this.Owner = owner ?? throw new ArgumentNullException($"{nameof(owner)} is null");
            this.AccountType = accountType ?? throw new ArgumentNullException($"{nameof(accountType)} is null");
            this.Id = Guid.NewGuid();
        }

        public Client Owner { get; }

        public Guid Id { get; }

        public IAccountType AccountType { get; internal set; }

        public decimal Cash
        {
            get => this.cash;
            private set
            {
                if (value <= 0)
                {
                    throw new InvalidOperationException($"{nameof(value)} must be positive!");
                }

                this.cash = value;
            }
        }

        public void Deposit(decimal amount)
        {
            decimal roundedAmount = Math.Round(amount, 2);

            if (roundedAmount <= 0)
            {
                throw new InvalidOperationException($"{nameof(amount)} must be positive");
            }

            roundedAmount += AccountType.Increase(roundedAmount);

            this.Cash += roundedAmount;
        }

        public void Withdraw(decimal amount)
        {
            decimal roundedAmount = Math.Round(amount, 2);

            if (roundedAmount <= 0)
            {
                throw new InvalidOperationException($"{nameof(amount)} must be positive");
            }

            roundedAmount -= AccountType.Decrease(roundedAmount);

            this.Cash -= roundedAmount;
        }
    }
}
