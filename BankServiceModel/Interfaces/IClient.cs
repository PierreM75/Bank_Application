namespace BankServiceModel.Interfaces
{
    public interface IClient : IAccount
    {
        string ClientName();
    }
}