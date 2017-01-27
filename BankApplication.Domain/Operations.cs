using System.Collections.Generic;
using System.Linq;
using BankApplication.Domain.Operation;
using BankApplication.Model;

namespace BankApplication.Domain
{
    internal class Operations
    {
        private readonly List<BaseOperation> operations;
        
        internal Operations()
        {
            operations = new List<BaseOperation>();
        }

        internal BankMessage Execute(BaseOperation operation)
        {
            var message = operation.IsAllowed(Balance());
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