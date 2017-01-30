using System;
using System.Linq;
using BankApplication.Model;
using BankApplication.Model.Filter;
using BankApplication.Model.Interface;
using BankApplication.Model.Operation;

namespace BankApplication.Console
{
    internal class AccountConsole
    {
        internal static void AccountScreen(IClient client)
        {
            while (true)
            {
                System.Console.Clear();
                System.Console.WriteLine(
                    $"Welcome dear {client.Name()}. Your balance account is {client.Balance()} €.");
                System.Console.WriteLine("1: Deposit");
                System.Console.WriteLine("2: Withdrawal");
                System.Console.WriteLine("3: Transfert");
                System.Console.WriteLine("4: Statements");
                System.Console.WriteLine("q: Quit");
                var userInput = System.Console.ReadKey();
                System.Console.WriteLine();

                switch (userInput.KeyChar)
                {
                    case '1':
                        client.Deposit(new Operation(DateTime.Now, SelectAmount()));
                        break;
                    case '2':
                        client.Withdrawal(new Operation(DateTime.Now, SelectAmount()));
                        break;
                    case '3':
                        client.Transfert(ClientConsole.GetClient(), new Operation(DateTime.Now, SelectAmount()));
                        break;
                    case '4':
                        System.Console.WriteLine("Date - Operation - Amount - Balance");
                        client.Statements(new PeriodFilter(DateTime.MinValue, DateTime.MaxValue), new AmountFilter())
                            .ToList()
                            .ForEach(statement => System.Console.WriteLine(statement.ShowStatement()));
                        
                        System.Console.ReadLine();
                        break;
                    case 'q':
                        return;
                }
            }
        }

        private static int SelectAmount()
        {
            var success = false;
            var amount = 0;
            while (!success)
            {
                System.Console.Write("How much?:");
                success = int.TryParse(System.Console.ReadLine(), out amount);
            }

            return amount;
        }
    }
}