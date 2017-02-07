using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _16Jan2016.AccountTypes;
using _16Jan2016.Operations;

namespace _16Jan2016
{
    public class TotalBalanceVisitor : ITransactionVisitor
    {
        public IAccountType AccountType;

        public IAccountState AccountState;

        public AccountManager Account;
        public decimal TotalBalance { get; set; }

        public TotalBalanceVisitor()
        {
        
            Account = new AccountManager();

        }
        public void visit(Deposite deposite)
        {
            Account.Deposit(deposite.DepositeAmount,deposite.TransactionDate);

        }

        public void visit(Withdraw withdraw)
        {
            Account.Withdraw(withdraw.WithdrawAmount,withdraw.TransactionDate);
        }


        public void visit(BalanceEnquiry balanceEnquiry)
        {
            throw new NotImplementedException();
        }

        public void visit(ChangeAccount changeAccount)
        {
            Account.ChangeAccountType(changeAccount.AccountType,changeAccount.TransactionDate);
        }

        public void visit(AddAccount addAccount)
        {
            Account.AddAccount(addAccount);
        }

        public void visit(AddInterest addInterest)
        {
            Account.AddInterst();
        }

        
    }
}
