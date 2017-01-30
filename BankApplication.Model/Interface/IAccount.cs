using System.Collections.Generic;
using BankApplication.Model.Filter;
using BankApplication.Model.Operation;

namespace BankApplication.Model.Interface
{
    public interface IAccount
    {
        TransactionStatus Deposit(Operation.Operation operation);

        TransactionStatus Withdrawal(Operation.Operation operation);

        TransactionStatus Transfert(IAccount receiver, Operation.Operation operation);

        IEnumerable<Statement> Statements (PeriodFilter periodFilter, AmountFilter amountFilter);

        int Balance();
    }
}