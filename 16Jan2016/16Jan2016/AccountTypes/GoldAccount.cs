namespace _16Jan2016.AccountTypes
{
    class GoldAccount : IAccountType
    {
        private const decimal InterestRate = 3;
        private const decimal CashBackRate = 1;

        private const decimal MinimumBalance = 0;
        private const decimal Penalty = 0;
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
