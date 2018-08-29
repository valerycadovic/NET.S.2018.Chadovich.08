namespace BankSystem.BLL.Interface.Entities
{
    using System;
    using System.Text.RegularExpressions;

    public class AccountHolder : IEquatable<AccountHolder>
    {
        private string _email;

        private string _name;

        public AccountHolder(string passportId, string name, string email)
        {
            this.PassportId = passportId;
            this.Name = name;
            this.Email = email;
        }

        public string PassportId { get; }

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

        public override int GetHashCode()
        {
            return (PassportId != null ? PassportId.GetHashCode() : 0);
        }
        #endregion
    }
}
