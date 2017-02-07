namespace _16Jan2016.AccountTypes
{
    public interface IAccountType
    {
        decimal CalculateCashBack(decimal amount);

        decimal CalculateInterest(decimal amount,double NoOfDays);

        decimal CalculatePenlaty(decimal balanceAmount);

    }
}
