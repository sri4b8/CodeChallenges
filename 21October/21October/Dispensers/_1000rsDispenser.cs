using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _21October.Interface;

namespace _21October.Dispensers
{
    public class _1000rsDispenser : IDenominationChain
    {
        private IDenominationChain chain;
        public void SetNextDenominationChain(IDenominationChain denominationChain)
        {
            chain = denominationChain;
        }

        public void Dispense(Currency currency)
        {
            if (currency.getAmount() >= 1000)
            {
                int number = currency.getAmount() / 1000;
                int reminder = currency.getAmount() % 1000;
                DisplayDenominations displayDenominations = new DisplayDenominations(1000, number);
                displayDenominations.Display();
                if (reminder > 0)
                {
                    chain.Dispense(new Currency(reminder));
                }
            }
            else
            {
                chain.Dispense(currency);
            }
        }
    }
}
