using System.Collections.Generic;
using System.Linq;
using BankApplication.Model.Interface;

namespace BankApplication.Domain
{
    public class Clients : IClients
    {
        private readonly List<IClient> clients;

        public Clients()
        {
            clients = new List<IClient>();
        }

        public void Create(IClient client)
        {
            clients.Add(client);
        }

        public IClient Select(string clientName)
        {
            return clients.FirstOrDefault(cl => cl.Name() == clientName);
        }
    }
}