using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystem.Core;

namespace BankSystem.Accounts
{
    public class SilverAccount : BankAccount
    {
        private static readonly decimal DecreasingCoefficient;

        private static readonly decimal IncreasingCoefficient;

        private static readonly int MaxBonusCount;

        private static readonly decimal MaxCredit;

        static SilverAccount()
        {
            try
            {
                DecreasingCoefficient = decimal.Parse(ConfigurationManager.AppSettings["silverDecrease"]);
                IncreasingCoefficient = decimal.Parse(ConfigurationManager.AppSettings["silverIncrease"]);
                MaxCredit = decimal.Parse(ConfigurationManager.AppSettings["silverMaxCredit"]);
                MaxBonusCount = int.Parse(ConfigurationManager.AppSettings["silverMaxBonus"]);
            }
            catch
            {
                DecreasingCoefficient = 0.005M;
                IncreasingCoefficient = 0.02M;
                MaxCredit = -100.00M;
                MaxBonusCount = 500;
            }
        }

        public SilverAccount(
            AccountHolder holder,
            IAccountNumberGenerator idGenerator,
            IMoneyAccuracyCalculator rounder = null) :
            base(holder, idGenerator, rounder)
        {
        }

        protected override void DecreaseBalance(decimal amount)
        {
            if (this.Balance - amount < MaxCredit)
            {
                throw new ArgumentException($"{nameof(amount)} must be greater than {nameof(this.Balance)} + ({nameof(MaxCredit)})");
            }
            this.Balance -= amount;
        }

        protected override void DecreaseBonusPoints(decimal amount)
        {
            var bonusWithdraw = (int)(amount * DecreasingCoefficient);

            if (bonusWithdraw <= this.BonusPoints)
            {
                this.BonusPoints -= bonusWithdraw;
            }
        }

        protected override void IncreaseBalance(decimal amount)
        {
            this.Balance += amount;
        }

        protected override void IncreaseBonusPoints(decimal amount)
        {
            var bonusDeposit = (int)(amount * IncreasingCoefficient);

            if (bonusDeposit + this.BonusPoints >= MaxBonusCount)
            {
                this.BonusPoints = MaxBonusCount;
            }
            this.BonusPoints += bonusDeposit;
        }
    }
}
