using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public abstract class BankAccountType : IAccountType
    {
        private decimal totalCost;

        public decimal TotalCost
        {
            get => this.totalCost;
            protected set
            {
                if (value <= 0)
                {
                    this.totalCost = 0;
                }

                this.totalCost = value;
            }
        }

        public decimal Increase(decimal d)
        {
            ValidateInput(d);

            return IncreaseDimension(d);
        }

        public decimal Decrease(decimal d)
        {
            ValidateInput(d);

            return DecreaseDimension(d);
        }

        protected abstract decimal IncreaseDimension(decimal d);

        protected abstract decimal DecreaseDimension(decimal d);

        private void ValidateInput(decimal d)
        {
            if (d <= 0)
            {
                throw new InvalidOperationException($"{nameof(d)} must be positive");
            }
        }
    }
}
