using BankApplication.Domain.Transaction;
using BankApplication.Model;
using BankApplication.Model.Interface;

namespace BankApplication.Domain
{
    public class Account : IAccount
    {
        private readonly Transactions transactions = new Transactions();

        public TransactionMessage Deposit(Operation operation)
        {
            var transaction = new Credit(operation);
            var status = ExecuteTransaction(transaction);

            return new TransactionMessage(status, transaction.Statement());
        }
        
        public TransactionMessage Withdrawal(Operation operation)
        {
            var transaction = new Debit(operation);
            var status = ExecuteTransaction(transaction);
            
            return new TransactionMessage(status, transaction.Statement());
        }

        public TransactionMessage Transfert(IAccount receiver, Operation operation)
        {
            var message = Withdrawal(operation);
            if (message.Status() == TransactionStatus.Success)
            {
                receiver.Deposit(operation);
            }
            
            return message;
        }

        public int Balance()
        {
            return transactions.Balance();
        }

        private TransactionStatus ExecuteTransaction(TransactionBase transaction)
        {
            var status = transaction.IsValid(Balance());
            if (status == TransactionStatus.Success)
            {
                transactions.AddTransaction(transaction);
            }

            return status;
        }
    }
}