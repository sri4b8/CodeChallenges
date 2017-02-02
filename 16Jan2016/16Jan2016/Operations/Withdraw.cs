﻿namespace _16Jan2016
{
    public class Withdraw : ITransaction
    {
        public decimal WithdrawAmount { get; set; }

        public void Accept(ITransactionVisitor transactionVisitor)
        {
            transactionVisitor.visit(this);
        }
    }
}