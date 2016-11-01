using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _21October.Interface;

namespace _21October.Dispensers
{
    public class _500rsDispenser : IDenominationChain
    {
        private IDenominationChain chain;
        public void SetNextDenominationChain(IDenominationChain denominationChain)
        {
            chain = denominationChain;
        }

        public void Dispense(Currency currency)
        {
            if (currency.getAmount() >= 500)
            {
                int number = currency.getAmount() / 500;
                int reminder = currency.getAmount() % 500;

                DisplayDenominations displayDenominations = new DisplayDenominations(500, number);
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
