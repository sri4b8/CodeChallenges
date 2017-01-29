using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _16Jan2016.Exceptions;

namespace _16Jan2016
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Select AccountType: 1.GoldAccount  2.Diamond account 3.Platinum account");
                string accountType = Console.ReadLine();
                Console.WriteLine("Select Account State:1.Active 2.Close 3.I-Operative");
                string accountState = Console.ReadLine();
                Console.WriteLine("Initial Balance:");
                decimal InitialBalance = Convert.ToDecimal(Console.ReadLine());


                BankAccount bankAccount = new BankAccount();
                bool isprocess = true;
                List<ITransaction> transactions = new List<ITransaction>();
                while (isprocess)
                {
                    Console.WriteLine(
                        "Select Operation: 1.Deposit Money 2.WithDraw Money 3.Change AccountType 4.Exit to Get Statement");
                    string opration = Console.ReadLine();
                    switch (opration)
                    {
                        case "1":
                            Console.WriteLine("Deposite Amount:");
                            transactions.Add(new Deposite
                            {
                                DepositeAmount = Convert.ToDecimal(Console.ReadLine()),
                                AccountType = GetAccountType(accountType)
                            });
                            break;
                        case "2":
                            Console.WriteLine("Withdraw Amount:");

                            transactions.Add(new Withdraw
                            {
                                WithdrawAmount = Convert.ToDecimal(Console.ReadLine()),
                                AccountType = GetAccountType(accountType)
                            });
                            break;
                        case "3":
                            Console.WriteLine("Select AccountType: 1.GoldAccount  2.Diamond account 3.Platinum account");
                            accountType = Console.ReadLine();
                            break;
                        default:
                            isprocess = false;
                            break;
                    }

                }

                bankAccount.Transactions = transactions;

                var totalBalanceVisitor = new TotalBalanceVisitor(GetAccountState(accountState),
                    InitialBalance);

                bankAccount.Accept(totalBalanceVisitor);

                Console.WriteLine("Cashback: " + totalBalanceVisitor.Account.CashBack);

                Console.WriteLine("Total Balance: " + totalBalanceVisitor.Account.Balance);


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
