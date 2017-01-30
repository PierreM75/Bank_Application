using BankApplication.Model.Filter;
using BankApplication.Model.Operation;

namespace BankApplication.Model
{
    public class Statement
    {
        private readonly Operation.Operation operation;
        private readonly OperationDetail operationDetail;

        public Statement(Operation.Operation operation, OperationDetail operationDetail)
        {
            this.operation = operation;
            this.operationDetail = operationDetail;
        }

        public string ShowStatement()
        {
            return
                $"{operation.Date():dd/MM/yyy} - {operationDetail.OperationType()} - {operation.Amount():F} - {operationDetail.Balance():F}";
        }

        public bool FilterByPeriod(PeriodFilter periodFilter)
        {
            return
                operation.Date() >= periodFilter.Minimum()
                && operation.Date() < periodFilter.Maximum();
        }

        public bool FilterByAmount(AmountFilter amountFilter)
        {
            return
                operation.Amount() >= amountFilter.Minimum()
                && operation.Amount() < amountFilter.Maximum();
        }
    }
}