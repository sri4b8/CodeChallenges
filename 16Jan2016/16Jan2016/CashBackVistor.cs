using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16Jan2016
{
    public class CashBackVistor : ITransactionVisitor
    {
        public IAccountType AccoutType;

        public IAccountState AccountState;
        public decimal TotalCashBack { get; set; }

        public CashBackVistor(IAccountType accountType, IAccountState accountState)
        {
            AccoutType = accountType;
            AccountState = accountState;
        }
        public void visit(BalanceEnquiry balanceEnquiry)
        {
           // AccoutType.CalculateCashBack(balanceEnquiry.)
            //throw new NotImplementedException();
        }

        public void visit(Withdraw withdraw)
        {

            TotalCashBack += AccoutType.CalculateCashBack(withdraw.WithdrawAmount);
            //  throw new NotImplementedException();
        }

        public void visit(Deposite deposite)
        {
            TotalCashBack += AccoutType.CalculateCashBack(deposite.DepositeAmount);

            // throw new NotImplementedException();
        }
    }
}
