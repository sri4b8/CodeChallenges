using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16Jan2016
{
    public class BankAccount :ITransaction
    {
        public decimal InitialBalance { get; set; }

        public List<ITransaction> Transactions=new List<ITransaction>(); 
        public void Accept(ITransactionVisitor transactionVisitor)
        {
            foreach (var transaction in Transactions)
            {
                transaction.Accept(transactionVisitor);
            }

        }
    }
}
