using System;

namespace _16Jan2016
{
    class ActiveState : IAccountState
    {

        
        public IAccountState Deposit(Action addToBalance)
        {
            addToBalance();
            return this;
        }

        public IAccountState Withdraw(Action subtractFromBalance)
        {
            subtractFromBalance();
            return this;
        }

        public IAccountState CalculateInterst(Action InterestCalculation)
        {
            InterestCalculation();
            return this;
        }


        public IAccountState InOperative() => new InOperativeState();
        public IAccountState Close() => new ClosedState();
        public IAccountState Active() => this;

    }
}