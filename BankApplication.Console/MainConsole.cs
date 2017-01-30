using BankApplication.Domain;
using BankApplication.Model.Interface;

namespace BankApplication.Console
{
    internal class MainConsole
    {
        internal static readonly IClients Context = new Clients();

        private static void Main(string[] args)
        {
            while (true)
            {
                ClientConsole.ClientScreen();
            }
        }
    }
}