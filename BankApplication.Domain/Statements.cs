using System.Collections.Generic;
using System.Linq;
using BankApplication.Domain.Transaction;
using BankApplication.Model;
using BankApplication.Model.Filter;

namespace BankApplication.Domain
{
    internal class Statements
    {
        private List<Statement> statements;

        internal Statements(IEnumerable<TransactionBase> transactions)
        {
            var balance = 0;
            statements = new List<Statement>();
            foreach (var transaction in transactions)
            {
                balance += transaction.Amount();
                statements.Add(transaction.Statement(balance));
            }

            statements.Reverse();
        }

        internal IEnumerable<Statement> Filter(PeriodFilter periodFilter, AmountFilter amountFilter)
        {
            FilterByPeriod(periodFilter);
            FilterByAmount(amountFilter);
            return statements;
        }

        private void FilterByAmount(AmountFilter amountFilter)
        {
            statements = (from statement in statements
                where statement.FilterByAmount(amountFilter)
                select statement).ToList();
        }

        private void FilterByPeriod(PeriodFilter periodFilter)
        {
            statements = (from statement in statements
                where statement.FilterByPeriod(periodFilter)
                select statement).ToList();
        }
    }
}