namespace _16Jan2016
{
    public class Deposite :ITransaction
    {
        public decimal DepositeAmount { get; set; }

        public IAccountType AccountType { get; set; }
        public void Accept(ITransactionVisitor transactionVisitor)
        {
           transactionVisitor.visit(this);
        }
    }
}