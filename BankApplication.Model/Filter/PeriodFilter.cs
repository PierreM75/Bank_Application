using System;

namespace BankApplication.Model.Filter
{
    public class PeriodFilter : Filter<DateTime>
    {
        public PeriodFilter(DateTime minimum = default(DateTime), DateTime maximum = default(DateTime)) : base(minimum, maximum)
        {   
        }
    }
}