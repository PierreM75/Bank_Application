using BankApplication.Model.Interface;

namespace BankApplication.Domain
{
    public class Client : Account, IClient
    {
        private readonly string name;

        public Client(string clientName)
        {
            name = clientName;
        }

        public string Name()
        {
            return name;
        }
    }
}