using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class OneHumdredthAccuracy : IMoneyAccuracyCalculator
    {
        public decimal RoundUp(decimal exactAmount) => Math.Round(exactAmount, 2);
    }
}
