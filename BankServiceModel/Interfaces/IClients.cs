namespace BankServiceModel.Interfaces
{
    public interface IClients
    {
        void Add(IClient client);

        IClient GetClientByName(string clientName);
    }
}