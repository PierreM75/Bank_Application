using BankApplication.Domain;
using BankApplication.Model;
using BankApplication.Model.Interface;

namespace BankApplication.Tests
{
    internal class BankApplicationContext
    {
        private readonly IClients clients = new Clients();
        private TransactionMessage message;

        internal void CreateClientAccount(string clientName, int amount, string date)
        {
            var client = new Client(clientName);
            clients.Create(client);
            message = client.Deposit(new Operation(date.ConvertDate(), amount));
        }

        internal void Deposit(string clientName, int amount, string date)
        {
            message = GetClient(clientName).Deposit(new Operation(date.ConvertDate(), amount));
        }

        internal void Withdrawal(string clientName, int amount, string date)
        {
            var operation = new Operation(date.ConvertDate(), amount);
            message = GetClient(clientName).Withdrawal(operation);
        }

        internal void Transfert(string fromClientName, string toClientName, int amount, string date)
        {
            var fromClient = GetClient(fromClientName);
            var toClient = GetClient(toClientName);
            var operation = new Operation(date.ConvertDate(), amount);
            message = fromClient.Transfert(toClient, operation);
        }

        internal int GetBalance(string clientName)
        {
            return GetClient(clientName).Balance();
        }

        internal TransactionMessage Message()
        {
            return message;
        }

        internal IClient GetClient(string clientName)
        {
            var client = clients.Select(clientName);
            return client;
        }
    }
}