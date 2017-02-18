namespace _1._1
{
    using System.Text;
    using static System.Console;
    using static System.Math;
    using static System.Environment;

    public static class Drawing
    {
        /// <summary> 1.1.2 </summary>
        public static void Smiley(int radius)
        {
            int d = radius << 1, d1 = d + 1;
            int hafr = radius >> 1;
            int sesqui = radius + hafr;

            StringBuilder result = new StringBuilder();
            for (int y = 0; y < d1; y++)
            {
                for (int x = 0; x < d1; x++)
                {
                    char ch = ' ';
                    int a = y - radius, b = x - radius;
                    int c = (int)Round(Sqrt(a * a + b * b));

                    if (c == radius) ch = '*';
                    else if (x == hafr || x == sesqui)
                    {
                        if (y == hafr - 1) ch = '_';
                        else if (y == hafr) ch = '0';
                    }
                    else if (y == sesqui && x > hafr && x < sesqui) ch = '-';
                    else if (y == radius && x == radius) ch = '#';

                    result.Append(ch);
                }

                if (y < d) result.Append(NewLine);
            }

            Write(result.ToString());
        }

        /// <summary> 1.1.1 </summary>
        public static void RectTriangle(int width)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 1; i < width; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    sb.Append('*');
                }

                sb.Append(NewLine);
            }

            Write(sb.ToString());
        }
    }
}