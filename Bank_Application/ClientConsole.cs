using BankApplication.Domain;
using BankApplication.Model.Interface;

namespace BankApplication.Console
{
    internal class ClientConsole
    {
        internal static void ClientScreen()
        {
            IClient client = null;
            while (client == null)
            {
                System.Console.Clear();
                System.Console.WriteLine("Welcome to Bank Application.");
                System.Console.WriteLine("1: Select client's account");
                System.Console.WriteLine("2: Create new client's account");
                System.Console.WriteLine("q: Quit");
                var userInput = System.Console.ReadKey();
                switch (userInput.KeyChar)
                {
                    case '1':
                        client = GetClient();
                        break;
                    case '2':
                        client = CreateClient();
                        break;
                    case 'q':
                        return;
                }
            }

            AccountConsole.AccountScreen(client);
        }

        internal static IClient GetClient()
        {
            IClient client = null;
            while (client == null)
            {
                System.Console.WriteLine("Please Indicate the client's name or press q to quit and press enter:");
                var userInput = System.Console.ReadLine();
                if (userInput == "q")
                {
                    return null;
                }

                client = MainConsole.Context.Select(userInput);
                System.Console.WriteLine(client == null ? "Unknown client." : "Client loaded.");
            }

            return client;
        }

        private static IClient CreateClient()
        {
            System.Console.WriteLine("Enter new user:");
            var client = new Client(System.Console.ReadLine());
            MainConsole.Context.Create(client);
            return client;
        }
    }
}