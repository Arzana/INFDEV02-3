﻿//#define ENABLE_TYPE_ERROR_EXAMPLE

namespace _1._1
{
    using static System.Console;
    using static System.Math;

    public static class Program
    {
        public static void Main(string[] args)
        {
            //Drawing.RectTriangle(9);                          // 1.1.1

            //Drawing.Smiley(10);                               // 1.1.2

            //WriteSum();                                       // 1.1.4

            //WriteLine(new Interval(1, 5));                    // 1.1.6

            //WriteLine(new IntArrayOperations(1, 2, 3, 4, 5)); // 1.1.7

            //Counter c = new Counter();                        // 1.1.8
            //c.OnTarget(0, () => WriteLine("First!"));
            //c.OnTarget(1, () => WriteLine("Second!"));
            //c++;

            WriteLine("Press any key to continue...");
            ReadKey();
        }

        /// <summary> 1.1.3 </summary>
#if ENABLE_TYPE_ERROR_EXAMPLE
        def Func(_0, _1):
            pass
#endif

        /// <summary> 1.1.4 </summary>
        public static void WriteSum()
        {
            int _0 = GetIntInput(), _1 = GetIntInput(), sum = 0;

            for (int i = Min(_0, _1) + 1; i < Max(_0, _1); i++) sum += i;

            WriteLine("Sum: {0}", sum);
        }

        private static int GetIntInput()
        {
            int result;

            do
            {
                Write("Please input a integer number: ");
            } while (!int.TryParse(ReadLine(), out result));

            return result;
        }
    }
}