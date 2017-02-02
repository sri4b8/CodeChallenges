using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16Jan2016
{
    public class InterestCalculatorVisitor :ITransactionVisitor
    {
        public IAccountType AccountType;

        public IAccountState AccountState;


        public InterestCalculatorVisitor(IAccountState accountState, decimal intitialBalance)
        {
            
        }

        public void visit(Deposite deposite)
        {
           
        }

        public void visit(Withdraw withdraw)
        {
            
        }

        public void visit(BalanceEnquiry balanceEnquiry)
        {
            throw new NotImplementedException();
        }

        public void visit(ChangeAccount accountType)
        {
            throw new NotImplementedException();
        }
    }
}
