using System;
using _16Jan2016;

namespace _16Jan2016
{
    class InOperativeState : IAccountState
    {


        public IAccountState Deposit(Action addToBalance)
        {
            addToBalance();
            return new ActiveState();
        }

        public IAccountState Withdraw(Action subtractFromBalance)
        {
            subtractFromBalance();
            return new ActiveState();
        }

        public IAccountState CalculateInterst(Action InterestCalculation) => this;
        public IAccountState InOperative() => this;


        //   public IAccountState InOperative() => this;
        public IAccountState Close() => new ClosedState();
        public IAccountState Active() => new ActiveState();

    }
}