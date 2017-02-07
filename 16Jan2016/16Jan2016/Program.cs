using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _16Jan2016.AccountTypes;
using _16Jan2016.Exceptions;
using _16Jan2016.Operations;

namespace _16Jan2016
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                List<ITransaction> transactions = new List<ITransaction>();

                Console.WriteLine("Select AccountType: 1.GoldAccount  2.Diamond account 3.Platinum account");
                string accountType = Console.ReadLine();

                Console.WriteLine("Select Account State:1.Active 2.Close 3.I-Operative");
                string accountState = Console.ReadLine();
                Console.WriteLine("Initial Balance:");
                decimal InitialBalance = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Account Open Date:");
                DateTime accountOpenDate = Convert.ToDateTime(Console.ReadLine());

                transactions.Add(new AddAccount
                {
                    AccountState = GetAccountState(accountState),
                    AccountType = GetAccountType(accountType),
                    TransactionDate = accountOpenDate,
                    InitialBalance = InitialBalance

                });

                BankAccount bankAccount = new BankAccount();
                bool isprocess = true;
                decimal amount;
                DateTime transactionDate;
                while (isprocess)
                {
                    Console.WriteLine(
                        "Select Operation: 1.Deposit Money 2.WithDraw Money 3.Change AccountType 4.Exit to Get Statement");
                    string opration = Console.ReadLine();
                    switch (opration)
                    {
                        case "1":
                            Console.WriteLine("Deposite Amount:");
                            amount = Convert.ToDecimal(Console.ReadLine());

                            Console.WriteLine("Transaction Date (dd/mm/yyyy):");
                            transactionDate = Convert.ToDateTime(Console.ReadLine());
                            transactions.Add(new Deposite
                            {
                                DepositeAmount = amount,
                                TransactionDate = transactionDate
                            });
                            break;
                        case "2":
                            Console.WriteLine("Withdraw Amount:");
                            amount = Convert.ToDecimal(Console.ReadLine());

                            Console.WriteLine("Transaction Date (dd/mm/yyyy):");
                            transactionDate = Convert.ToDateTime(Console.ReadLine());

                            transactions.Add(new Withdraw
                            {
                                WithdrawAmount = amount,
                                TransactionDate = transactionDate
                            });
                            break;
                        case "3":
                            Console.WriteLine("Select AccountType: 1.GoldAccount  2.Diamond account 3.Platinum account");
                            accountType = Console.ReadLine();
                            Console.WriteLine("Changed Date (dd/mm/yyyy):");
                            transactionDate = Convert.ToDateTime(Console.ReadLine());
                            transactions.Add(new ChangeAccount
                            {
                                AccountType = GetAccountType(accountType),
                                TransactionDate = transactionDate
                            });
                            break;
                        default:
                            isprocess = false;
                            transactions.Add(new AddInterest());
                            break;
                    }

                }

                bankAccount.Transactions = transactions;

                var totalBalanceVisitor = new TotalBalanceVisitor();


                bankAccount.Accept(totalBalanceVisitor);

                Console.WriteLine("Cashback: " +  totalBalanceVisitor.Account.CashBack.ToString("#.000"));

                Console.WriteLine("Interst: " + totalBalanceVisitor.Account.Interest.ToString("#.000"));

                Console.WriteLine("Total Balance: " + totalBalanceVisitor.Account.Balance.ToString("#.000"));


            }

            catch (LowBalanceException ex)
            {

                Console.WriteLine("Withdraw Amount should be less then balnce Amount :" + ex.Balance);
            }
            catch (AccountClosedException ex)
            {
                Console.WriteLine("Account Closed");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Enter to exit application");

                Console.ReadLine();
            }

        }

        public static IAccountType GetAccountType(string type)
        {
            switch (type)
            {
                case "1":
                    return new GoldAccount();

                case "2":
                    return new DiamondAccount();

                case "3":
                    return new PlatinumAccount();
                default:
                    return null;

            }
        }

        public static IAccountState GetAccountState(string state)
        {
            switch (state)
            {
                case "1":
                    return new ActiveState();
                case "2":
                    return new ClosedState();
                case "3":
                    return new InOperativeState();
                default:
                    return null;

            }
        }
    }
}
