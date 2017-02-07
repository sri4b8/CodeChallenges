using System;

namespace _16Jan2016.Operations
{
    public class Deposite :ITransaction
    {
        public decimal DepositeAmount { get; set; }

        public DateTime TransactionDate { get; set; }

        public void Accept(ITransactionVisitor transactionVisitor)
        {
           transactionVisitor.visit(this);
        }
    }
}