using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class GoldenState : BankAccountType
    {
        private static readonly int decreaseCost;

        private static readonly int increaseCost;

        static GoldenState()
        {
            try
            {
                decreaseCost = int.Parse(ConfigurationManager.AppSettings["goldenDecrease"]);
                increaseCost = int.Parse(ConfigurationManager.AppSettings["goldenIncrease"]);
            }
            catch (Exception)
            {
                decreaseCost = 1;
                increaseCost = 7;
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
