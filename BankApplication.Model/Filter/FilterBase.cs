namespace BankApplication.Model.Filter
{
    public abstract class Filter<T> where T : struct
    {
        private readonly T minimun;
        private readonly T maximum;

        protected Filter(T minimum, T maximum)
        {
            this.minimun = minimum;
            this.maximum = maximum;
        }

        public virtual T Minimum()
        {
            return minimun;
        }

        public virtual T Maximum()
        {
            return maximum;
        }
    }
}