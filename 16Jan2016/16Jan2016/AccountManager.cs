using System;
using System.Runtime.CompilerServices;
using _16Jan2016.AccountTypes;
using _16Jan2016.Exceptions;
using _16Jan2016.Operations;

namespace _16Jan2016
{
    public class AccountManager
    {
        public decimal Interest { get; set; }
        public decimal Balance { get; set; }

        public DateTime LastTransactionDate { get; set; }

        public decimal CashBack { get; private set; }

        private IAccountState State { get; set; }

        public IAccountType AccountType { get; set; }

        public AccountManager()
        {
           this.State=new ClosedState();
            this.AccountType = new GoldAccount();//default Account type
        }


        public void Deposit(decimal amount, DateTime transactionDate)
        {
            CalculateInterst(transactionDate);
            this.State = this.State.Deposit(() =>
            {

                decimal cashback = AccountType.CalculateCashBack(amount);

                this.Balance += amount + cashback;
                this.Balance -= AccountType.CalculatePenlaty(this.Balance);
                this.CashBack += cashback;
            });
        }

        public void Withdraw(decimal amount, DateTime transactionDate)
        {
            CalculateInterst(transactionDate);

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

        public void ChangeAccountType(IAccountType accountType, DateTime transactionDate)
        {
            // Interest = +accountType.CalculateInterest(this.Balance);
            CalculateInterst(transactionDate);
            this.AccountType = accountType;
        }
        public void Close()
        {
            this.State = this.State.Close();
        }

        public void InOperative()
        {
            this.State = this.State.InOperative();
        }


        public void AddInterst()
        {
            CalculateInterst(DateTime.Now);

            this.Balance += this.Interest;
        }

        public void AddAccount(AddAccount addAccount)
        {
            this.State = addAccount.AccountState;
            this.AccountType = addAccount.AccountType;
            this.LastTransactionDate = addAccount.TransactionDate;
            this.Balance = addAccount.InitialBalance;

        }
        private void CalculateInterst(DateTime transactionDate)
        {
            double noOfDays = (transactionDate - LastTransactionDate).TotalDays;

            this.State = this.State.CalculateInterst(() =>
            {

                decimal interest = AccountType.CalculateInterest(this.Balance, noOfDays);

                this.Interest += interest;
            });

            this.LastTransactionDate = transactionDate;

        }






    }
}
