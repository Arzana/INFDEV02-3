namespace _1._1
{
    public sealed class IntArrayOperations
    {
        private int[] nums;
        private int sum, product;
        private ByteFlags flags;

        public IntArrayOperations(params int[] numbers)
        {
            nums = numbers;
            product = 1;
        }

        public int Sum()
        {
            if (flags.CheckSet(0))
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    sum += nums[i];
                }
            }

            return sum;
        }

        public int Product()
        {
            if (flags.CheckSet(1))
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    product *= nums[i];
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