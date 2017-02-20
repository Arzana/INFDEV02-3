namespace _2._1
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using static System.Console;

    public static class Program
    {
        public static void Main(string[] args)
        {
            //TestAnimals();      // 2.1.1
            //MoveVehicles();     // 2.1.3
            //TestNodeInt();      // 2.1.4
            //TestStateMachine(); // 2.1.5

            WriteLine("Press any key to continue...");
            ReadKey();
        }

        /// <summary> 2.1.1 </summary>
        private static void TestAnimals()
        {
            new Cat().SaySomething();
            new Dog().SaySomething();
            new Cow().SaySomething();
        }

        /// <summary> 2.1.3 </summary>
        private static void MoveVehicles()
        {
            Random rndGen = new Random();
            Vehicle[] vehicles = new Vehicle[3];

            for (int i = 0, rnd = rndGen.Next(0, 3); i < vehicles.Length; i++, rnd = rndGen.Next(0, 3))
            {
                if (rnd == 0) vehicles[i] = new Car();
                else if (rnd == 1) vehicles[i] = new Truck();
                else vehicles[i] = new Enterprise();
            }

            for (int i = 0, moves = 0; i < vehicles.Length; i++, moves = 0)
            {
                vehicles[i].LoadFuel(new Diesel(20));
                while (vehicles[i].Move()) ++moves;
                WriteLine($"Vehicle_{i}({vehicles[i].GetType().Name}) has stopped after {moves} turns.");
            }
        }

        /// <summary> 2.1.4 </summary>
        private static void TestNodeInt()
        {
            using (NodeInt n = new NodeInt(1, 2, 3, 4, 5))
            {
                Write("Collection:\t");
                n.Iterate(WriteNum);
                Write(Environment.NewLine);

                Write("Filter (>2):\t");
                n.Filter((v) => v > 2).Iterate(WriteNum);
                Write(Environment.NewLine);

                Write("Map (+1):\t");
                n.Map((v) => v + 1).Iterate(WriteNum);
                Write(Environment.NewLine);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void WriteNum(int n) => Write($"{n} ");

        /// <summary> 2.1.5 </summary>
        private static void TestStateMachine()
        {
            IStateMachine s = new Repeat(new Sequence(new Wait(10), new Print("Hello world")));
            while(!s.Done)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                s.Update(1);    // ^ lazy cheat so I don't have to install monogame :P
            }
        }
    }
}