using BankServiceModel.Interfaces;

namespace BankService
{
    public class Client : Account, IClient
    {
        private readonly string name;

        public Client(string clientName)
        {
            name = clientName;
        }

        public string ClientName()
        {
            return name;
        }
    }
}