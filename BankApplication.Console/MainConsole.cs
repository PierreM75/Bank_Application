using BankApplication.Domain;
using BankApplication.Model.Interface;

namespace BankApplication.Console
{
    internal class MainConsole
    {
        internal static readonly IClients Context = new Clients();
        static void Main(string[] args)
        {
            ClientConsole.ClientScreen();
        }
    }
}
