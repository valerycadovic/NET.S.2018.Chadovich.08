using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class BaseState : BankAccountType
    {
        private static readonly decimal decreaseCost;

        private static readonly decimal increaseCost;

        static BaseState()
        {
            try
            {
                decreaseCost = int.Parse(ConfigurationManager.AppSettings["baseDecrease"]);
                increaseCost = int.Parse(ConfigurationManager.AppSettings["baseIncrease"]);
            }
            catch (Exception)
            {
                decreaseCost = 1;
                increaseCost = 2;
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
