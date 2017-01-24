using System.Collections.Generic;
using System.Linq;
using BankServiceModel.Interfaces;

namespace BankService
{
    public class Clients : IClients
    {
        private readonly List<IClient> clients;

        public Clients()
        {
            clients = new List<IClient>();
        }

        public void Add(IClient client)
        {
            clients.Add(client); 
        }

        public IClient GetClientByName(string clientName)
        {
            return clients.FirstOrDefault(cl => cl.ClientName() == clientName);
        }
    }
}