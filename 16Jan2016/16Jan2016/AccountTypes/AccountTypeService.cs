using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _16Jan2016.AccountTypes;

namespace _16Jan2016
{
    public class AccountTypeService
    {
        public IAccountType AccountType;
        public AccountTypeService(IAccountType accountType)
        {
            this.AccountType = accountType;
        }

        public decimal CalculateCashBack(decimal amount)
        {
            return this.AccountType.CalculateCashBack(amount);
        }

        public decimal CalculateInterest(decimal amount,double noOfDays)
        {
            return this.AccountType.CalculateInterest(amount,noOfDays);

        }

        public decimal CalculatePenlaty(decimal balanceAmount)
        {
            return this.AccountType.CalculatePenlaty(balanceAmount);

        }
    }
}
