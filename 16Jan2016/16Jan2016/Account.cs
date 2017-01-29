using System;
using _16Jan2016.Exceptions;

namespace _16Jan2016
{
    public class Account
    {

        public decimal Balance { get; set; }

        public decimal CashBack { get; private set; }

        private IAccountState State { get; set; }

        public IAccountType AccountType { get; set; }

        public Account(IAccountState accountState)
        {
            this.State = accountState;
            this.AccountType = new GoldAccount();//default Account type
        }


        public void Deposit(decimal amount)
        {
            this.State = this.State.Deposit(() =>
            {

                decimal cashback = AccountType.CalculateCashBack(amount);

                this.Balance += amount + cashback;
                this.Balance -= AccountType.CalculatePenlaty(this.Balance);
                this.CashBack += cashback;
            });
        }

        public void Withdraw(decimal amount)
        {
            this.State = this.State.Withdraw(() =>
            {
                if (this.Balance < amount)
                {
                    throw new LowBalanceException(this.Balance);
                }

                decimal cashback = AccountType.CalculateCashBack(amount);
                this.Balance -= amount;
                this.Balance += cashback;
                this.Balance -= AccountType.CalculatePenlaty(this.Balance);
                this.CashBack += cashback;


            });
        }


        public void Close()
        {
            this.State = this.State.Close();
        }

        public void InOperative()
        {
            this.State = this.State.InOperative();
        }

    }
}
