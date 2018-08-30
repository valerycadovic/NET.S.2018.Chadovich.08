namespace BankSystem.BLL.Interface.Entities.Accounts
{
    using System;
    using Interfaces;

    /// <summary>
    /// Represents bank account model
    /// </summary>
    /// <seealso cref="System.IEquatable{Account}" />
    public abstract class Account : IEquatable<Account>
    {
        #region Constructors        
        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="holder">The holder.</param>
        /// <param name="scorer">The scorer.</param>
        /// <param name="status">The status.</param>
        /// <exception cref="ArgumentNullException">
        /// holder
        /// or
        /// scorer
        /// </exception>
        protected Account(string number, AccountHolder holder, IBonusCalculator scorer, AccountStatus status)
        {
            this.Number = number;
            this.Holder = holder ?? throw new ArgumentNullException($"{nameof(holder)} is null");
            this.BonusCalculator = scorer ?? throw new ArgumentNullException($"{nameof(scorer)} is null");
            this.Status = status;
        }
        #endregion

        #region Readonly properties        
        /// <summary>
        /// Gets the number.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        public string Number { get; }

        /// <summary>
        /// Gets the holder.
        /// </summary>
        /// <value>
        /// The holder.
        /// </value>
        public AccountHolder Holder { get; }

        /// <summary>
        /// Gets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public AccountStatus Status { get; }

        /// <summary>
        /// Gets the bonus calculator.
        /// </summary>
        /// <value>
        /// The bonus calculator.
        /// </value>
        public IBonusCalculator BonusCalculator { get; }
        #endregion

        #region Immutable properties        
        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <value>
        /// The balance.
        /// </value>
        public decimal Balance { get; protected set; }

        /// <summary>
        /// Gets the bonus points.
        /// </summary>
        /// <value>
        /// The bonus points.
        /// </value>
        public int BonusPoints { get; private set; }
        #endregion

        #region Public template methods        
        /// <summary>
        /// Deposits the specified amount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        public void Deposit(decimal amount)
        {
            ValidateOnStatus(nameof(Deposit));

            decimal roundedAmount = RoundUp(amount);

            this.DepositBalance(roundedAmount);
            this.BonusPoints += this.BonusCalculator.GetDepositBonus(this, roundedAmount);
        }

        /// <summary>
        /// Withdraws the specified amount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <exception cref="InvalidOperationException">
        /// Throws when <seealso cref="AccountStatus"/> is frozen
        /// </exception>
        public void Withdraw(decimal amount)
        {
            ValidateOnStatus(nameof(Withdraw));

            decimal roundedAmount = RoundUp(amount);

            this.WithdrawBalance(roundedAmount);
            this.BonusPoints += this.BonusCalculator.GetWithdrawBonus(this, roundedAmount);
        }
        #endregion

        #region Equality members        
        /// <summary>
        /// Указывает, эквивалентен ли текущий объект другому объекту того же типа.
        /// </summary>
        /// <param name="other">Объект, который требуется сравнить с данным объектом.</param>
        /// <returns>
        /// <see langword="true" />, если текущий объект эквивалентен параметру <paramref name="other" />, в противном случае — <see langword="false" />.
        /// </returns>
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

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
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

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }
        #endregion

        #region Abstract methods        
        /// <summary>
        /// Deposits the balance.
        /// </summary>
        /// <param name="amount">The amount.</param>
        protected abstract void DepositBalance(decimal amount);

        /// <summary>
        /// Withdraws the balance.
        /// </summary>
        /// <param name="amount">The amount.</param>
        protected abstract void WithdrawBalance(decimal amount);
        #endregion

        #region Private methods        
        /// <summary>
        /// Rounds up.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>
        /// decimal
        /// </returns>
        private static decimal RoundUp(decimal number) => Math.Round(number, 2);

        /// <summary>
        /// Validates the status.
        /// </summary>
        /// <param name="operationName">Name of the operation.</param>
        /// <exception cref="InvalidOperationException"></exception>
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
