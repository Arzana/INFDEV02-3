namespace _3._1
{
    using static System.Console;

    public static class Program
    {
        public static void Main(string[] args)
        {
            //TestTraficLight();
            //TestCar();

            WriteLine("Press any key to continue...");
            ReadKey();
        }

        public static void TestTraficLight()
        {
            TraficLight tl = new TraficLight();
            tl.LightChanged += (s, e) => WriteLine($"Light changed to: {tl.LightColor.Name}.");
            WriteLine($"Traficlight started, light: {tl.LightColor.Name}.");

            while (true)
            {
                tl.Update();
            }
        }

        public static void TestCar()
        {
            Mercedes m = new Mercedes();
            WriteLine($"Start test, fuel level: {m.TankLevel}, dist: {m.DistanceTraveled}.");

            while (m.TankLevel > 0)
            {
                m.Update(1);
                WriteLine($"Tick test, fuel level: {m.TankLevel}, dist: {m.DistanceTraveled}.");
            }

            WriteLine("End test.");
        }
    }
}