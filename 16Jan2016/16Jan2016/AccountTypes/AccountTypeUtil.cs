using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16Jan2016.AccountTypes
{
    public static class AccountTypeUtil
    {
        public static decimal CalculateCashBack(decimal amount,decimal CashBackRate)
        {
            return amount * CashBackRate / 100;
        }

        public static decimal CalculateInterest(decimal amount, double NoOfDays,decimal InterestRate)
        {
            return (amount * InterestRate * (decimal)NoOfDays) / (365 * 100);

        }

        public static decimal CalculatePenlaty(decimal balanceAmount,decimal MinimumBalance,decimal Penalty)
        {
            return balanceAmount < MinimumBalance ? Penalty : 0;
        }
    }
}
