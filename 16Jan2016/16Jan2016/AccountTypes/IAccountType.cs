using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16Jan2016
{
    public interface IAccountType
    {
        decimal CalculateCashBack(decimal amount);

        decimal CalculateInterest(decimal amount);

        decimal CalculatePenlaty(decimal balanceAmount);

    }
}
