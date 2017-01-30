using System;

namespace BankApplication.Model.Filter
{
    public class AmountFilter : Filter<int>
    {
        public AmountFilter(int minimum = int.MinValue, int maximum = int.MaxValue) : base(minimum, maximum)
        {
        }
    }
}