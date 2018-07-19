using BankSystem.Core;

namespace BankSystem
{
    using System;

    public abstract class BankAccount : IEquatable<BankAccount>
    { 
        private readonly IMoneyAccuracyCalculator rounder;

        protected BankAccount(AccountHolder holder, IAccountNumberGenerator idGenerator, IMoneyAccuracyCalculator rounder = null)
        {
            ValidateOnNull(holder, nameof(holder));

            this.Id = idGenerator.GenerateAccountNumber();
            this.rounder = rounder ?? new OneHundredthAccuracy();
            this.Holder = holder;
        }

        public string Id { get; }

        public int BonusPoints { get; protected set; }
        
        public AccountHolder Holder { get; }

        public AccountStatus Status { get; set; }

        public decimal Balance { get; protected set; }

        public bool Equals(BankAccount other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(Id, other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((BankAccount)obj);
        }

        public override int GetHashCode()
        {
            return Id != null ? Id.GetHashCode() : 0;
        }

        public void Deposit(decimal amount)
        {
            ValidateOnStatus(nameof(this.Deposit));

            decimal roundedAmount = this.rounder.RoundUp(amount);

            ValidateOnAmount(roundedAmount, nameof(amount));

            IncreaseBalance(roundedAmount);
            IncreaseBonusPoints(roundedAmount);
        }

        public void Withdraw(decimal amount)
        {
            ValidateOnStatus(nameof(this.Withdraw));

            decimal roundedAmount = this.rounder.RoundUp(amount);

            ValidateOnAmount(roundedAmount, nameof(amount));

            DecreaseBalance(roundedAmount);
            DecreaseBonusPoints(roundedAmount);
        }

        protected abstract void IncreaseBalance(decimal amount);

        protected abstract void DecreaseBalance(decimal amount);

        protected abstract void IncreaseBonusPoints(decimal amount);

        protected abstract void DecreaseBonusPoints(decimal amount);

        private static void ValidateOnNull<T>(T obj, string name) where T : class
        {
            if (obj is null)
            {
                throw new ArgumentNullException($"{name} is null");
            }
        }

        private static void ValidateOnAmount(decimal amount, string name)
        {
            if (amount <= 0M)
            {
                throw new ArgumentOutOfRangeException($"{name} must be positive to be performed");
            }
        }

        private void ValidateOnStatus(string operationName)
        {
            if (this.Status != AccountStatus.Open)
            {
                throw new InvalidOperationException($"{operationName} cannot be executed " +
                                                    $"while account status is not {nameof(AccountStatus.Open)}");
            }
        }
    }
}
