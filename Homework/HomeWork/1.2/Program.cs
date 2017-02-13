namespace _1._2
{
    using static System.Console;

    public static class Program
    {
        public static void Main(string[] args)
        {
            UserStory us0 = new UserStory();
            us0.SetHours(1);
            us0.SetDescription("Do homework");

            UserStory us1 = new UserStory();
            us1.SetHours(2);
            us1.SetDescription("Watch Youtube");

            UserStory us2 = new UserStory();
            us2.SetHours(3);
            us2.SetDescription("Go to bed");

            Sprint s = new Sprint();
            s.AddStory(us0);
            s.AddStory(us1);
            s.AddStory(us2);

            WriteLine(s);
            ReadKey();
        }
    }
}