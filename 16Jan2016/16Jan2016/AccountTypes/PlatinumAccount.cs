using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16Jan2016
{
    class PlatinumAccount :IAccountType
    {
        public decimal CalculateCashBack(decimal amount)
        {
            return amount * 5 / 100;
        }

        public decimal CalculateInterest(decimal amount)
        {
            return amount * 6 / 100;
        }

        public decimal CalculatePenlaty(decimal balanceAmount)
        {
            return balanceAmount < 25000 ? 5000 : 0;
        }
    }
}
