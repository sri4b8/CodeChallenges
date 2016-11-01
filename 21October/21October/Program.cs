using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _21October.Dispensers;
using _21October.Interface;

namespace _21October
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int amount = Convert.ToInt32(Console.ReadLine());

            if (amount % 100 == 0)
            {
                //using chain of responsibility pattern

                IDenominationChain _1000dispenser = new _1000rsDispenser();
                IDenominationChain _500dispenser = new _500rsDispenser();
                IDenominationChain _100dispenser = new _100rsDispenser();

                //setting the process link list 
                _1000dispenser.SetNextDenominationChain(_500dispenser);
                _500dispenser.SetNextDenominationChain(_100dispenser);

                //start processing 
                _1000dispenser.Dispense(new Currency(amount));

            }
            else
            {
                Console.WriteLine("Amount cannot be dispensed");
            }
            Console.ReadLine();
        }

    }
}
