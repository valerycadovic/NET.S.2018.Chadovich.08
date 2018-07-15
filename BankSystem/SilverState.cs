using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    class SilverState : BankAccountType
    {
        private static readonly int decreaseCost;

        private static readonly int increaseCost;

        static SilverState()
        {
            try
            {
                decreaseCost = int.Parse(ConfigurationManager.AppSettings["silverDecrease"]);
                increaseCost = int.Parse(ConfigurationManager.AppSettings["silverIncrease"]);
            }
            catch (Exception)
            {
                decreaseCost = 1;
                increaseCost = 5;
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
