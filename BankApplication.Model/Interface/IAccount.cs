namespace BankApplication.Model.Interface
{
    public interface IAccount
    {
        TransactionMessage Deposit(Operation operation);

        TransactionMessage Withdrawal(Operation operation);

        TransactionMessage Transfert(IAccount receiver, Operation operation);

        int Balance();
    }
}