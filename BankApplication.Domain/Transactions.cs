using System.Collections.Generic;
using System.Linq;
using BankApplication.Domain.Transaction;

namespace BankApplication.Domain
{
    internal class Transactions
    {
        private readonly List<TransactionBase> transactions;

        internal Transactions()
        {
            transactions = new List<TransactionBase>();
        }

        internal void AddTransaction(TransactionBase transaction)
        {
            transactions.Add(transaction);
        }

        internal int Balance()
        {
            return transactions.Sum(operation => operation.Amount());
        }
    }
}