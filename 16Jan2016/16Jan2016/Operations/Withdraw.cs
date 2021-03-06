﻿using System;

namespace _16Jan2016.Operations
{
    public class Withdraw : ITransaction
    {
        public decimal WithdrawAmount { get; set; }

        public DateTime TransactionDate { get; set; }


        public void Accept(ITransactionVisitor transactionVisitor)
        {
            transactionVisitor.visit(this);
        }
    }
}