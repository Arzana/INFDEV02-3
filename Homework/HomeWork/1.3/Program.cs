namespace _1._3
{
    using static System.Console;

    public static class Program
    {
        public static void Main(string[] args)
        {
            Sprint s = new Sprint
            {
                { 1, "Do Homework" },
                { 2, "Watch Youtube" },
                { 3, "Go to bed" }
            };

            ReadKey();
        }
    }
}