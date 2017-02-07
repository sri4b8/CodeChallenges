using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _16Jan2016.Operations;

namespace _16Jan2016
{
    public interface ITransactionVisitor
    {
        void visit(Deposite deposite);
        void visit(Withdraw withdraw);

        void visit(BalanceEnquiry balanceEnquiry);

        void visit(ChangeAccount accountType);

        void visit(AddAccount addAccount);
        void visit(AddInterest addInterst);
    }
}
