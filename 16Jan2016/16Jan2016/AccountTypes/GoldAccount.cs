using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16Jan2016
{
    class GoldAccount : IAccountType
    {
        public decimal CalculateCashBack(decimal amount)
        {
            return amount * 1 / 100;
        }

        public decimal CalculateInterest(decimal amount)
        {
            return amount * 3 / 100;
        }

        public decimal CalculatePenlaty(decimal balanceAmount)
        {
            return 0;
        }
    }
}
