using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16Jan2016
{
    public interface ITransaction
    {
        void Accept(ITransactionVisitor transactionVisitor);
    }
}
