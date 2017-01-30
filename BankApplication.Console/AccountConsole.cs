using System;
using BankApplication.Model;
using BankApplication.Model.Interface;

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
                    $"Welcome dear {client.Name()}. Your balance account is /d{client.Balance()} €.");
                System.Console.WriteLine("1: Deposit");
                System.Console.WriteLine("2: Withdrawal");
                System.Console.WriteLine("3: Transfert");
                System.Console.WriteLine("q: Quit");
                var userInput = System.Console.ReadKey();

                Operation operation = null;
                if (userInput.KeyChar != 'q')
                    operation = new Operation(DateTime.Today, SelectAmount());

                switch (userInput.KeyChar)
                {
                    case '1':
                        client.Deposit(operation);
                        break;
                    case '2':
                        client.Withdrawal(operation);
                        break;
                    case '3':
                        client.Transfert(ClientConsole.GetClient(), operation);
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
                System.Console.WriteLine("How much?:");
                success = int.TryParse(System.Console.ReadLine(), out amount);
            }

            return amount;
        }
    }
}