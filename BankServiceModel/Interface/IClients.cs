namespace BankApplication.Model.Interface
{
    public interface IClients
    {
        void Create(IClient client);

        IClient Select(string clientName);
    }
}