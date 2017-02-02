namespace _16Jan2016
{
    public class ChangeAccount :ITransaction
    {

        public  IAccountType AccountType { get; set; }
        public void Accept(ITransactionVisitor transactionVisitor)
        {
            transactionVisitor.visit(this);
        }
    }
}