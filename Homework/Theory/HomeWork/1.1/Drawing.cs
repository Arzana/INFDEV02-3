namespace _1._1
{
    using System.Text;
    using static System.Console;
    using static System.Math;
    using static System.Environment;

    public static class Drawing
    {
        /// <summary> 1.1.2 </summary>
        /// <remarks>
        /// * : Face
        /// _ : Eyebrow
        /// 0 : Eye
        /// - : Mouth
        /// # : Nose
        /// 
        /// Loop through the bounding box of the smiley (equal to its diameter (radius * 2) + 1)
        ///     Set the default character to a space
        ///     If the current point's direct distance to the middle is equal to the radius; set the character to the face character
        ///     If the current point's x is equal to the half of the radius or the radius and a half
        ///         If the current point's y is equal to the half of the radius - 1; set the character to the eyebrow character
        ///         If the current point's y is equal to the half of the radius; set the character to the eye character
        ///     If the current point's y is equal to the radius and a half and the x is between the half of the radius and the radius and a half; set the character to the mouth character
        ///     If the current point is the center point; set the character to the nose character
        /// </remarks>
        public static void Smiley(int radius)
        {
            int d = radius << 1, d1 = d + 1;
            int hr = radius >> 1;
            int sesqui = radius + hr;

            StringBuilder result = new StringBuilder();
            for (int y = 0; y < d1; y++)
            {
                for (int x = 0; x < d1; x++)
                {
                    char ch = ' ';
                    int a = y - radius, b = x - radius;
                    int c = (int)Round(Sqrt(a * a + b * b));

                    if (c == radius) ch = '*';
                    else if (x == hr || x == sesqui)
                    {
                        if (y == hr - 1) ch = '_';
                        else if (y == hr) ch = '0';
                    }
                    else if (y == sesqui && x > hr && x < sesqui) ch = '-';
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