using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21October
{
    public class DisplayDenominations
    {
        private int _denomination;
        private int _number;
        public DisplayDenominations(int denomination, int number)
        {
            _denomination = denomination;
            _number = number;
        }

        public void Display()
        {
            Console.WriteLine("{0} X {1}", _denomination, _number);
        }
    }
}
