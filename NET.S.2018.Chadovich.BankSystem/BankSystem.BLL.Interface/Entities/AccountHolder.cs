namespace BankSystem.BLL.Interface.Entities
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Represents a model of bank account holder
    /// </summary>
    /// <seealso cref="System.IEquatable{AccountHolder}" />
    public class AccountHolder : IEquatable<AccountHolder>
    {
        /// <summary>
        /// The email
        /// </summary>
        private string _email;

        /// <summary>
        /// The name
        /// </summary>
        private string _name;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountHolder"/> class.
        /// </summary>
        /// <param name="passportId">The passport identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="email">The email.</param>
        public AccountHolder(string passportId, string name, string email)
        {
            this.PassportId = passportId;
            this.Name = name;
            this.Email = email;
        }

        /// <summary>
        /// Gets the passport identifier.
        /// </summary>
        /// <value>
        /// The passport identifier.
        /// </value>
        public string PassportId { get; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        /// <exception cref="FormatException">
        /// Throws when value has invalid name format
        /// </exception>
        public string Name
        {
            get => this._name;
            set
            {
                Regex regex = new Regex(@"^([A-Z][a-z]*\s)+[A-Z][a-z]*$");

                if (!regex.IsMatch(value))
                {
                    throw new FormatException($"{nameof(value)} has wrong email format");
                }

                this._name = value;
            }
        }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        /// <exception cref="FormatException">
        /// Throws when value has invalid name format
        /// </exception>
        public string Email
        {
            get => this._email;
            set
            {
                Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})$");

                if (!regex.IsMatch(value))
                {
                    throw new FormatException($"{nameof(value)} has wrong name format");
                }

                this._email = value;
            }
        }

        #region Equality members        
        /// <summary>
        /// Указывает, эквивалентен ли текущий объект другому объекту того же типа.
        /// </summary>
        /// <param name="other">Объект, который требуется сравнить с данным объектом.</param>
        /// <returns>
        /// <see langword="true" />, если текущий объект эквивалентен параметру <paramref name="other" />, в противном случае — <see langword="false" />.
        /// </returns>
        public bool Equals(AccountHolder other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;

            }
            return string.Equals(PassportId, other.PassportId);
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

            return Equals((AccountHolder) obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return (PassportId != null ? PassportId.GetHashCode() : 0);
        }
        #endregion
    }
}
