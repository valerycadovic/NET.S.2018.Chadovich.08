namespace BankSystem
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class AccountHolder
    {
        #region Private fields
        private string phone;

        private string address;

        private string email;

        private readonly HashSet<BankAccount> accounts = new HashSet<BankAccount>();
        #endregion

        #region Constructors
        public AccountHolder(string name, string phone, string email)
        {
            ValidateName(name);
            this.Name = name;
            this.Phone = phone;
            this.Email = email;
        }
        #endregion

        #region Properties
        public string Email
        {
            get => this.email;
            set
            {
                ValidateStringOnNullOrEmpty(value, nameof(value));

                Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})$");

                if (!regex.IsMatch(value))
                {
                    throw new FormatException($"{nameof(value)} has wrong email format");
                }

                this.email = value;
            }
        }

        public string Name { get; }

        public string Phone
        {
            get => this.phone;
            private set
            {
                ValidateStringOnNullOrEmpty(value, nameof(value));

                Regex regex = new Regex(@"^\+\d{1,4}\s(\(\d{1,6}\))\s\d{3}-\d{4}$");

                if (!regex.IsMatch(value))
                {
                    throw new FormatException($"{nameof(value)} has wrong email format");
                }
            }
        }
        #endregion
        
        #region Public API
        public void AddAccount(BankAccount account)
        {
            if (account is null)
            {
                throw new ArgumentNullException($"{nameof(account)} is null");
            }

            this.accounts.Add(account);
        }

        public IEnumerable<BankAccount> GetAccounts() => this.accounts;
        #endregion

        #region Private Methods
        private static void ValidateName(string name)
        {
            ValidateStringOnNullOrEmpty(name, nameof(name));

            Regex regex = new Regex(@"^([A-Z][a-z]*\s)+[A-Z][a-z]*$");

            if (!regex.IsMatch(name))
            {
                throw new FormatException($"{nameof(name)} is invalid");
            }
        }

        private static void ValidateOnNull<T>(T obj, string name) where T : class
        {
            if (obj is null)
            {
                throw new ArgumentNullException($"{nameof(name)} is null");
            }
        }

        private static void ValidateStringOnNullOrEmpty(string @string, string name)
        {
            if (string.IsNullOrEmpty(@string))
            {
                throw new ArgumentException($"{name} is null or empty");
            }
        }
        #endregion
    }
}
