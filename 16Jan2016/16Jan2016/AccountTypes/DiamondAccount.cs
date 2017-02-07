namespace _16Jan2016.AccountTypes
{
    class DiamondAccount :IAccountType
    {
        private const decimal InterestRate = 4;
        private const decimal CashBackRate = 3;

        private const decimal MinimumBalance =5000;
        private const decimal Penalty = 1000;


        public decimal CalculateCashBack(decimal amount)
        {
            return AccountTypeUtil.CalculateCashBack(amount, CashBackRate);
        }

        public decimal CalculateInterest(decimal amount, double NoOfDays)
        {
            return AccountTypeUtil.CalculateInterest(amount, NoOfDays,InterestRate);

        }

        public decimal CalculatePenlaty(decimal balanceAmount)
        {
            return AccountTypeUtil.CalculatePenlaty(balanceAmount, MinimumBalance, Penalty);
        }
    }
}
