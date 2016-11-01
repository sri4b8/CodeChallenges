using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21October
{
   public class Currency
    {
        private  int amount;

        public Currency(int amt)
        {
            amount = amt;
        }

        public int getAmount()
        {
            return amount;
        }
    }
}
