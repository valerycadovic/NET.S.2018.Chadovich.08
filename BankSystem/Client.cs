using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankSystem
{
    public class Client
    {
        private string name;

        private List<IAccount> accounts = new List<IAccount>();

        public string Name
        {
            get => this.name;
            set
            {
                Regex regex = new Regex(@"^([A-Z][a-z]*\s)*[A-Z][a-z]*$");

                if (!regex.IsMatch(value))
                {
                    throw new FormatException($"{nameof(value)} is invalid");
                }

                this.name = value;
            }
        }
    }
}
