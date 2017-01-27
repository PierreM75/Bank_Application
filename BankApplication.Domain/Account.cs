using BankApplication.Domain.Operation;
using BankApplication.Model;
using BankApplication.Model.Interface;

namespace BankApplication.Domain
{
    public class Account: IAccount
    {
        private readonly Operations operations = new Operations();

        public BankMessage Deposit(OperationDetail operation)
        {
            return operations.Execute(new Credit(operation));
        }

        public BankMessage Withdrawal(OperationDetail operation)
        {
            return operations.Execute(new Debit(operation));
        }

        public BankMessage Transfert(IAccount receiver, OperationDetail operation)
        {
            var message = Withdrawal(operation);
            if (message.Status() != BankStatus.Success )
            {
                return message;
            }
            
            receiver.Deposit(operation);
            return message;
        }

        public int Balance()
        {
            return operations.Balance();
        }
    }
}