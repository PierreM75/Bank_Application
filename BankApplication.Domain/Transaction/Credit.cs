using BankApplication.Model;
using BankApplication.Model.Operation;

namespace BankApplication.Domain.Transaction
{
    internal sealed class Credit : TransactionBase
    {
        internal Credit(Operation operation) : base(OperationType.Credit, operation)
        {  
        }
        
        internal override TransactionStatus IsValid(int balance)
        {
            if (Amount() < 0)
            {
                return TransactionStatus.InvalidOperation;
            }

            return TransactionStatus.Success;
        }
    }
}