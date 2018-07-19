namespace BankSystem.Accounts
{
    using System;
    using System.Configuration;
    using BankSystem.Core;

    public class BaseAccount : BankAccount
    {
        private static readonly decimal DecreasingCoefficient;

        private static readonly decimal IncreasingCoefficient;

        private static readonly int MaxBonusCount;

        static BaseAccount()
        {
            try
            {
                DecreasingCoefficient = decimal.Parse(ConfigurationManager.AppSettings["baseDecrease"]);
                IncreasingCoefficient = decimal.Parse(ConfigurationManager.AppSettings["baseIncrease"]);
                MaxBonusCount = int.Parse(ConfigurationManager.AppSettings["baseMaxBonus"]);
            }
            catch
            {
                DecreasingCoefficient = 0.005M;
                IncreasingCoefficient = 0.01M;
                MaxBonusCount = 100;
            }
        }

        public BaseAccount(
            AccountHolder holder,
            IAccountNumberGenerator idGenerator,
            IMoneyAccuracyCalculator rounder = null) : 
            base(holder, idGenerator, rounder)
        {
        }

        protected override void IncreaseBalance(decimal amount)
        {
            this.Balance += amount;
        }

        protected override void DecreaseBalance(decimal amount)
        {
            if (amount > this.Balance)
            {
                throw new ArgumentException($"{nameof(amount)} cannot be greater than {nameof(this.Balance)}");
            }

            this.Balance -= amount;
        }

        protected override void IncreaseBonusPoints(decimal amount)
        {
            var bonusDeposit = (int)(IncreasingCoefficient * amount);

            if (this.BonusPoints + bonusDeposit >= MaxBonusCount)
            {
                this.BonusPoints = 100;
                return;
            }

            this.BonusPoints += bonusDeposit;
        }

        protected override void DecreaseBonusPoints(decimal amount)
        {
            var bonusWithdraw = (int)(IncreasingCoefficient * amount);

            if (bonusWithdraw > this.BonusPoints)
            {
                this.BonusPoints -= bonusWithdraw;
            }
        }
    }
}
