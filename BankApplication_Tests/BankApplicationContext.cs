using BankService;
using BankServiceModel;
using BankServiceModel.Interfaces;

namespace BankApplicationTests
{
    internal class BankApplicationContext
    {
        private readonly IClients clients = new Clients();
        private MessageServiceType message;
        
        internal void CreateClientAccount(string clientName, int amount, string date)
        {
            var client = new Client(clientName);
            message = client.Deposit(date.ConvertDate(), amount);
            clients.Add(client);
        }

        internal void Deposit(string clientName, int amount, string date)
        {
            var client = GetClient(clientName);
            message = client.Deposit(date.ConvertDate(), amount);
        }
        
        internal void Withdrawal(string clientName, int amount, string date)
        {
            var client = GetClient(clientName);
            message = client.Withdrawal(date.ConvertDate(), amount);
        }

        internal void Transfert(string fromClientName, string toClientName, int amount, string date)
        {
            var fromClient = GetClient(fromClientName);
            var toClient = GetClient(toClientName);

            message = fromClient.Transfert(toClient, date.ConvertDate(), amount);
        }

        internal int GetBalance(string clientName)
        {
            var client = GetClient(clientName);
            return client.GetBalanceAccount();
        }

        internal string Message()
        {
            return message.ToString();
        }

        private IClient GetClient(string clientName)
        {
            var client = clients.GetClientByName(clientName);
            return client;
        }
    }
}