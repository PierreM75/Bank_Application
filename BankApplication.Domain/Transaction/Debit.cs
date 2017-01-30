using BankApplication.Model;
using BankApplication.Model.Operation;

namespace BankApplication.Domain.Transaction
{
    internal sealed class Debit : TransactionBase
    {
        internal Debit(Operation operation) : base(OperationType.Debit, operation)
        {   
        }

        internal override int Amount()
        {
            return -base.Amount();
        }

        internal override TransactionStatus IsValid(int balance)
        {
            if (Amount() > 0)
            {
                return TransactionStatus.InvalidOperation;
            }

            if (balance + Amount() < 0)
            {
                return TransactionStatus.InsufficientFund;
            }

            return TransactionStatus.Success;
        }
    }
}