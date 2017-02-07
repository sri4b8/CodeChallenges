namespace _16Jan2016.Operations
{
    public class BalanceEnquiry : ITransaction
    {

        public void Accept(ITransactionVisitor transactionVisitor)
        {
            transactionVisitor.visit(this);
        }
    }
}