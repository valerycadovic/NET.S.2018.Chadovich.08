using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class PlatinumState : BankAccountType
    {
        private static readonly int decreaseCost;

        private static readonly int increaseCost;

        static PlatinumState()
        {
            try
            {
                decreaseCost = int.Parse(ConfigurationManager.AppSettings["baseDecrease"]);
                increaseCost = int.Parse(ConfigurationManager.AppSettings["baseIncrease"]);
            }
            catch (Exception)
            {
                decreaseCost = 1;
                increaseCost = 10;
            }
        }

        protected override decimal IncreaseDimension(decimal d)
        {
            var result = increaseCost / 100 * this.TotalCost;
            this.TotalCost += increaseCost / 100 * d;
            return result;
        }

        protected override decimal DecreaseDimension(decimal d)
        {
            var result = decreaseCost / 100 * this.TotalCost;
            this.TotalCost -= decreaseCost / 100 * d;
            return result;
        }
    }
}
