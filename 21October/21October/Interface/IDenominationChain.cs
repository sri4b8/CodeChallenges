using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21October.Interface
{
  public interface IDenominationChain
    {
        void SetNextDenominationChain(IDenominationChain denominationChain);
        void Dispense(Currency currency);

    }
}
