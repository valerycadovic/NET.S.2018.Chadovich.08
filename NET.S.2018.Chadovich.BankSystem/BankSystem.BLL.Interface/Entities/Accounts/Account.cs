namespace BankSystem.BLL.Interface.Entities.Accounts
{
    using System;
    using Interfaces;

    public abstract class Account : IEquatable<Account>
    {
        #region Constructors
        protected Account(string number, AccountHolder holder, IBonusScorer scorer, AccountStatus status)
        {
            this.Number = number;
            this.Holder = holder ?? throw new ArgumentNullException($"{nameof(holder)} is null");
            this.BonusScorer = scorer ?? throw new ArgumentNullException($"{nameof(scorer)} is null");
            this.Status = status;
        }
        #endregion

        #region Readonly properties
        public string Number { get; }

        public AccountHolder Holder { get; }

        public AccountStatus Status { get; }

        public IBonusScorer BonusScorer { get; }
        #endregion

        #region Immutable properties
        public decimal Balance { get; protected set; }

        public int BonusPoints { get; private set; }
        #endregion

        #region Public template methods
        public void Deposit(decimal amount)
        {
            ValidateOnStatus(nameof(Deposit));

            decimal roundedAmount = RoundUp(amount);

            this.DepositBalance(roundedAmount);
            this.BonusPoints += this.BonusScorer.GetDepositBonus(this, roundedAmount);
        }

        public void Withdraw(decimal amount)
        {
            ValidateOnStatus(nameof(Withdraw));

            decimal roundedAmount = RoundUp(amount);

            this.WithdrawBalance(roundedAmount);
            this.BonusPoints += this.BonusScorer.GetWithdrawBonus(this, roundedAmount);
        }
        #endregion

        #region Equality members
        public bool Equals(Account other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(Number, other.Number);
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
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

            return Equals((Account)obj);
        }

        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }
        #endregion

        #region Abstract methods
        protected abstract void DepositBalance(decimal amount);

        protected abstract void WithdrawBalance(decimal amount);
        #endregion

        #region Private methods
        private static decimal RoundUp(decimal number) => Math.Round(number, 2);

        private void ValidateOnStatus(string operationName)
        {
            if (this.Status != AccountStatus.Active)
            {
                throw new InvalidOperationException($"{operationName} cannot be executed " +
                                                    $"while account status is not {nameof(AccountStatus.Active)}");
            }
        }
        #endregion
    }
}
