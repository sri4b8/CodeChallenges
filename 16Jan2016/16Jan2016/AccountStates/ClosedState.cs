using System;
using System.CodeDom;
using _16Jan2016.Exceptions;

namespace _16Jan2016
{
    public class ClosedState : IAccountState
    {
        public IAccountState Deposit(Action addToBalance)
        {
            throw new AccountClosedException();
        }

        public IAccountState Withdraw(Action subtractFromBalance)
        {
            throw new AccountClosedException();
        }

        public IAccountState CalculateInterst(Action InterestCalculation) => this;


        public IAccountState InOperative() => this;
        public IAccountState Close() => this;

        public IAccountState Active() => this;

    }
}