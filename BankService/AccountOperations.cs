using System.Collections.Generic;
using System.Linq;
using BankService.Domain;

namespace BankService
{
    internal class AccountOperations
    {
        private readonly List<Operation> operations;
        
        internal AccountOperations()
        {
            operations = new List<Operation>();
        }

        internal void Add(Operation operation)
        {
             operations.Add(operation);   
        }
        
        internal int GetBalance()
        {
            return operations.Sum(operation => operation.GetAmount());
        }
    }
}
