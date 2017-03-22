namespace Assignment
{
#if WINDOWS || XBOX
    using Mentula.GuiItems;
    using System.Runtime.CompilerServices;
    using static System.Console;

    public static class Program
    {
        public static void Main(string[] args)
        {
            BufferHeight = short.MaxValue - 1;

            using (MainGame game = new MainGame())
            {
                game.Run();
            }

            WriteLine("Press enter to continue...");
            ReadLine();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LogAgmnt(string sender, string msg, string type)
        {
            Utilities.LogMsg("Assignment", sender, type, msg);
        }
    }
#endif
}