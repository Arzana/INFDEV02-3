namespace _1._1
{
    using static System.Math;

    /// <summary> 1.1.6 </summary>
    public sealed class Interval
    {
        private int start, end, sum, product;
        private ByteFlags flags;

        public Interval(int start, int end)
        {
            this.start = Min(start, end) + 1;
            this.end = Max(start, end);
            product = 1;
        }

        public int Sum()
        {
            if (flags.CheckSet(0))
            {
                for (int i = start; i < end; i++)
                {
                    sum += i;
                }
            }

            return sum;
        }

        public int Product()
        {
            if (flags.CheckSet(1))
            {
                for (int i = start; i < end; i++)
                {
                    product *= i;
                }
            }

            return product;
        }

        public override string ToString()
        {
            return $"{{ Sum: {Sum()}, Product: {Product()} }}";
        }
    }
}