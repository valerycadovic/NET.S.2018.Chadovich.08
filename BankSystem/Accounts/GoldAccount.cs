using BankSystem.Core;

namespace BankSystem.Accounts
{
    using System;
    using System.Configuration;

    public class GoldAccount : BankAccount
    {
        private static readonly decimal DecreasingCoefficient;

        private static readonly decimal IncreasingCoefficient;

        private static readonly int MaxBonusCount;

        private static readonly decimal MaxCredit;

        static GoldAccount()
        {
            try
            {
                DecreasingCoefficient = decimal.Parse(ConfigurationManager.AppSettings["goldDecrease"]);
                IncreasingCoefficient = decimal.Parse(ConfigurationManager.AppSettings["goldIncrease"]);
                MaxCredit = decimal.Parse(ConfigurationManager.AppSettings["goldMaxCredit"]);
                MaxBonusCount = int.Parse(ConfigurationManager.AppSettings["goldMaxBonus"]);
            }
            catch
            {
                DecreasingCoefficient = 0.005M;
                IncreasingCoefficient = 0.03M;
                MaxCredit = -1000.00M;
                MaxBonusCount = 5000;
            }
        }

        public GoldAccount(
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
