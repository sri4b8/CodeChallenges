namespace _16Jan2016.AccountTypes
{
    class PlatinumAccount :IAccountType
    {
        private const decimal InterestRate = 6;
        private const decimal CashBackRate = 5;

        private const decimal MinimumBalance = 25000;
        private const decimal Penalty = 5000;
        public decimal CalculateCashBack(decimal amount)
        {
            return AccountTypeUtil.CalculateCashBack(amount, CashBackRate);
        }

        public decimal CalculateInterest(decimal amount, double NoOfDays)
        {
            return AccountTypeUtil.CalculateInterest(amount, NoOfDays, InterestRate);

        }

        public decimal CalculatePenlaty(decimal balanceAmount)
        {
            return AccountTypeUtil.CalculatePenlaty(balanceAmount, MinimumBalance, Penalty);
        }
    }
}
