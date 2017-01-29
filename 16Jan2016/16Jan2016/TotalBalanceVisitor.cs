using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16Jan2016
{
    public class TotalBalanceVisitor : ITransactionVisitor
    {
        public IAccountType AccountType;

        public IAccountState AccountState;

        public Account Account;
        public decimal TotalBalance { get; set; }

        public TotalBalanceVisitor(IAccountState accountState, decimal intitialBalance)
        {
            AccountState = accountState;

            Account = new Account(AccountState) { Balance = intitialBalance };

        }
        public void visit(Deposite deposite)
        {
            Account.AccountType = deposite.AccountType;
            Account.Deposit(deposite.DepositeAmount);

        }

        public void visit(Withdraw withdraw)
        {
            Account.AccountType = withdraw.AccountType;

            Account.Withdraw(withdraw.WithdrawAmount);

        }

        public void visit(BalanceEnquiry balanceEnquiry)
        {
            throw new NotImplementedException();
        }
    }
}
