namespace BankApplication.Model.Interface
{
    public interface IAccount
    {
        BankMessage Deposit(OperationDetail operation);

        BankMessage Withdrawal(OperationDetail operation);

        BankMessage Transfert(IAccount receiver, OperationDetail operation);

        int Balance();
    }
}