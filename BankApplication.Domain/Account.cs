using System;
using System.Collections.Generic;
using BankApplication.Domain.Transaction;
using BankApplication.Model;
using BankApplication.Model.Interface;
using System.Linq;
using BankApplication.Model.Filter;
using BankApplication.Model.Operation;

namespace BankApplication.Domain
{
    public class Account : IAccount
    {
        private readonly Transactions transactions = new Transactions();

        public TransactionStatus Deposit(Operation operation)
        {
            var transaction = new Credit(operation);
            return Execute(transaction);
        }
        
        public TransactionStatus Withdrawal(Operation operation)
        {
            var transaction = new Debit(operation);
            return Execute(transaction);
        }

        public TransactionStatus Transfert(IAccount receiver, Operation operation)
        {
            var status = Withdrawal(operation);
            if (status == TransactionStatus.Success)
            {
                receiver.Deposit(operation);
            }
            
            return status;
        }

        public IEnumerable<Statement> Statements(PeriodFilter periodFilter, AmountFilter amountFilter)
        {
            var statements = new Statements(transactions.GetAll());
            return statements.Filter(periodFilter, amountFilter);
        } 

        public int Balance()
        {
            return transactions.Balance();
        }

        private TransactionStatus Execute(TransactionBase transaction)
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