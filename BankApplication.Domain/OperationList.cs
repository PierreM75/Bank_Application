using System.Collections.Generic;
using System.Linq;
using BankApplication.Domain.Operation.Base;
using BankApplication.Model;

namespace BankApplication.Domain
{
    internal class OperationList
    {
        private readonly List<BaseOperation> operations;
        
        internal OperationList()
        {
            operations = new List<BaseOperation>();
        }

        internal BankMessage Execute(BaseOperation operation)
        {
            var message = operation.Allowed(Balance());
            if (message.Status() == BankStatus.Success)
            {
                operations.Add(operation);
            }

            return message;
        }
        
        internal int Balance()
        {
            return operations.Sum(operation => operation.Amount());
        }
    }
}