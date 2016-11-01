using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _21October.Interface;

namespace _21October.Dispensers
{

    public class _100rsDispenser : IDenominationChain
    {
        private IDenominationChain chain;
        public void SetNextDenominationChain(IDenominationChain denominationChain)
        {
            chain = denominationChain;
        }

        public void Dispense(Currency currency)
        {
            if (currency.getAmount() >= 100)
            {
                int number = currency.getAmount() / 100;
                int reminder = currency.getAmount() % 100;
                DisplayDenominations displayDenominations = new DisplayDenominations(100, number);
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
