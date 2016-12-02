using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _21October.Dispensers;
using _21October.Interface;

namespace _21October
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //using  Abstract Factory Design Pattern 
            CheckStatus();
        }

     
        public static void CheckStatus()
        {
            Console.WriteLine("Select 1.deposit  2.withdraw   3.BalanceEnquiry");
            OperationType operationType = (OperationType)Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Select Account type - 1.Active  2.Closed  3.In-Operative");
            AccountType accountType =(AccountType)Convert.ToInt16(Console.ReadLine());

            ATMProcess process = new ATMProcess();
            var type = process.GetOperation(accountType);
            string resultAccountType=string.Empty;
            bool validOperation=false;

            switch (operationType)
            {
                case OperationType.Deposite:
                    var deposit = type.GetDeposit();
                    resultAccountType = deposit.GetAccountStatus();
                    validOperation = deposit.IsValidTransaction();
                    break;
                case OperationType.Withdraw:
                    var withDraw = type.GetWithdraw();
                    resultAccountType = withDraw.GetAccountStatus();
                    validOperation = withDraw.IsValidTransaction();
                    break;
                case OperationType.BalanceEnquiry:
                    var balnceEnquiry = type.GeBalanceEnquiry();
                    resultAccountType = balnceEnquiry.GetAccountStatus();
                    validOperation = balnceEnquiry.IsValidTransaction();
                    break;
            }

            Console.WriteLine(validOperation.ToString());
            Console.WriteLine(resultAccountType);

            Console.ReadLine();
        }


        public static void WithdrawAmmount()
        {
            int amount = Convert.ToInt32(Console.ReadLine());

            if (amount % 100 == 0)
            {
                //using chain of responsibility pattern

                IDenominationChain _1000dispenser = new _1000rsDispenser();
                IDenominationChain _500dispenser = new _500rsDispenser();
                IDenominationChain _100dispenser = new _100rsDispenser();

                //setting the process link list 
                _1000dispenser.SetNextDenominationChain(_500dispenser);
                _500dispenser.SetNextDenominationChain(_100dispenser);

                //start processing 
                _1000dispenser.Dispense(new Currency(amount));

            }
            else
            {
                Console.WriteLine("Amount cannot be dispensed");
            }
            Console.ReadLine();
        }

    }

    public class ATMProcess
    {
        public IATM GetOperation(AccountType type)
        {
            switch (type)
            {
                case AccountType.Active:
                    return new Active();
                case AccountType.Close:
                    return new Close();
                case AccountType.InOperative:
                    return new InOperative();
                default:
                    return new Close();
            }
        }

    }

    public interface IATM
    {
        IDeposit GetDeposit();
        IWithdraw GetWithdraw();
        IBalanceEnquiry GeBalanceEnquiry();
    }

    public interface IDeposit
    {
        string GetAccountStatus();
        bool IsValidTransaction();
    }

    public interface IWithdraw
    {
        string GetAccountStatus();
        bool IsValidTransaction();
    }

    public interface IBalanceEnquiry
    {
        string GetAccountStatus();
        bool IsValidTransaction();
    }

    public class Active : IATM
    {
        public IDeposit GetDeposit()
        {
            return new Deposite(AccountType.Active);

        }

        public IWithdraw GetWithdraw()
        {
            return new WithDraw(AccountType.Active);
        }

        public IBalanceEnquiry GeBalanceEnquiry()
        {
            return new BalanceEnquiry(AccountType.Active);
        }

    }

    public class Close : IATM
    {
        public IDeposit GetDeposit()
        {
            return new Deposite(AccountType.Close);

        }

        public IWithdraw GetWithdraw()
        {
            return new WithDraw(AccountType.Close);
        }

        public IBalanceEnquiry GeBalanceEnquiry()
        {
            return new BalanceEnquiry(AccountType.Close);
        }
    }

    public class InOperative : IATM
    {
        public IDeposit GetDeposit()
        {
            return new Deposite(AccountType.InOperative);

        }

        public IWithdraw GetWithdraw()
        {
            return new WithDraw(AccountType.InOperative);
        }

        public IBalanceEnquiry GeBalanceEnquiry()
        {
            return new BalanceEnquiry(AccountType.InOperative);
        }
    }

    public class Deposite : IDeposit
    {
        private AccountType accountType;
      public  Deposite(AccountType type)
      {
          accountType = type;
      }
        public string GetAccountStatus()
        {
            switch (accountType)
            {
                case AccountType.Active:
                    return "Active";
                case AccountType.Close:
                    return "Close";
                case AccountType.InOperative:
                    return "Active";
                default:
                    return "Close";
            }
        }

        public bool IsValidTransaction()
        {
            switch (accountType)
            {
                case AccountType.Active:
                    return true;
                case AccountType.Close:
                    return false;
                case AccountType.InOperative:
                    return true;
                default:
                    return false;
            }
        }
    }

    public class WithDraw : IWithdraw
    {
        private AccountType accountType;
        public WithDraw(AccountType type)
        {
            accountType = type;
        }
        public string GetAccountStatus()
        {
            switch (accountType)
            {
                case AccountType.Active:
                    return "Active";
                case AccountType.Close:
                    return "Close";
                case AccountType.InOperative:
                    return "Active";
                default:
                    return "Close";
            }
        }

        public bool IsValidTransaction()
        {
            switch (accountType)
            {
                case AccountType.Active:
                    return true;
                case AccountType.Close:
                    return false;
                case AccountType.InOperative:
                    return true;
                default:
                    return false;
            }
        }
    }

    public class BalanceEnquiry : IBalanceEnquiry
    {
        private AccountType accountType;
        public BalanceEnquiry(AccountType type)
        {
            accountType = type;
        }
        public string GetAccountStatus()
        {
            switch (accountType)
            {
                case AccountType.Active:
                    return "Active";
                case AccountType.Close:
                    return "Close";
                case AccountType.InOperative:
                    return "In-Operative";
                default:
                    return "Close";
            }
        }

        public bool IsValidTransaction()
        {
            switch (accountType)
            {
                case AccountType.Active:
                    return true;
                case AccountType.Close:
                    return true;
                case AccountType.InOperative:
                    return true;
                default:
                    return false;
            }
        }
    }


  

    public enum AccountType
    {
        Active=1,
        Close=2,
            InOperative=3
    }

    public enum OperationType
    {
        Deposite=1,
        Withdraw=2,
        BalanceEnquiry=3
    }
}
