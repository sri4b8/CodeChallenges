using System;

namespace _16Jan2016
{
   public interface IAccountState
    {
        IAccountState Deposit(Action addToBalance);
        IAccountState Withdraw(Action subtractFromBalance);
        IAccountState InOperative();
        IAccountState Close();

       IAccountState Active();
    }
}
