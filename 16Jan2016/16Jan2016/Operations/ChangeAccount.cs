﻿using System;
using _16Jan2016.AccountTypes;

namespace _16Jan2016.Operations
{
    public class ChangeAccount :ITransaction
    {

        public  IAccountType AccountType { get; set; }

        public DateTime TransactionDate { get; set; }

        public void Accept(ITransactionVisitor transactionVisitor)
        {
            transactionVisitor.visit(this);
        }
    }
}