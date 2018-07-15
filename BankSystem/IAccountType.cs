using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public interface IAccountType
    {
        decimal Increase(decimal d);
        decimal Decrease(decimal d);
    }
}
