using System;
using BankApplication.Model;
using BankApplication.Model.Operation;

namespace BankApplication.Domain.Transaction
{
    internal abstract class TransactionBase
    {
        private readonly OperationType operationType;
        private readonly Operation operation;
        
        protected TransactionBase(OperationType operationType, Operation operation)
        {
            this.operationType = operationType;
            this.operation = operation;
        }

        internal abstract TransactionStatus IsValid(int balance);

        internal virtual int Amount()
        {
            return operation.Amount();
        }

        internal DateTime Date()
        {
            return operation.Date();
        }
        
        internal Statement Statement(int balance)
        {
            return new Statement(
                operation,
                new OperationDetail(operationType, balance));
        }
    }
}