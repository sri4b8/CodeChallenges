using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16Jan2016.Exceptions
{
    public class LowBalanceException : Exception
    {
    
        public decimal Balance { get; set; }
        public LowBalanceException(decimal balance)
        {
            Balance = balance;
        }
    }
}
