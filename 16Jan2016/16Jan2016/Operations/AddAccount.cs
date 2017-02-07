using System;
using _16Jan2016.AccountTypes;

namespace _16Jan2016.Operations
{
    public class AddAccount : ITransaction
    {

        public  IAccountType AccountType { get; set; }

        public IAccountState AccountState { get; set; }

        public decimal InitialBalance { get; set; }

        public DateTime TransactionDate { get; set; }

        public void Accept(ITransactionVisitor transactionVisitor)
        {
            transactionVisitor.visit(this);
        }
    }
}