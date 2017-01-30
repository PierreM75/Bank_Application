using System;
using System.Collections.Generic;
using System.Linq;
using BankApplication.Domain.Transaction;

namespace BankApplication.Domain
{
    internal class Transactions
    {
        private readonly SortedList<DateTime, TransactionBase> transactions;

        internal Transactions()
        {
            transactions = new SortedList<DateTime, TransactionBase>();
        }
        
        internal void AddTransaction(TransactionBase transaction)
        {
            transactions.Add(transaction.Date(), transaction);
        }

        internal int Balance()
        {
            return transactions.Values.Sum(operation => operation.Amount());
        }
        
        internal IEnumerable<TransactionBase> GetAll()
        {
            return transactions.Values;
        }
    }
}