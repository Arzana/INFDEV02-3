namespace _2._1
{
    public interface Fuel
    {
        int Amount { get; }
        int PerUse { get; }
    }

    public interface Vehicle
    {
        bool Move();
        void LoadFuel(Fuel fuel);
    }

    public sealed class Gasoline : Fuel
    {
        public const int Efficiency = 10;

        public int Amount { get; set; }
        public int PerUse { get { return Efficiency; } }

        public Gasoline() { Amount = 0; }
        public Gasoline(int amount) { Amount = amount; }
    }

    public sealed class Diesel : Fuel
    {
        public const int Efficiency = 8;

        public int Amount { get; set; }
        public int PerUse { get { return Efficiency; } }

        public Diesel() { Amount = 0; }
        public Diesel(int amount) { Amount = amount; }
    }

    public sealed class Dilithium : Fuel
    {
        public const int Efficiency = 2;

        public int Amount { get; set; }
        public int PerUse { get { return Efficiency; } }

        public Dilithium() { Amount = 0; }
        public Dilithium(int amount) { Amount = amount; }
    }

    public sealed class Car : Vehicle
    {
        private Gasoline tank;

        public Car()
        {
            tank = new Gasoline();
        }

        public bool Move()
        {
            if (tank.Amount > 0)
            {
                tank.Amount -= tank.PerUse;
                return true;
            }

            return false;
        }

        public void LoadFuel(Fuel fuel)
        {
            if (fuel.PerUse == Gasoline.Efficiency) tank.Amount += fuel.Amount;
        }
    }

    public sealed class Truck : Vehicle
    {
        private Diesel tank;

        public Truck()
        {
            tank = new Diesel();
        }

        public bool Move()
        {
            if (tank.Amount > 0)
            {
                tank.Amount -= tank.PerUse;
                return true;
            }

            return false;
        }

        public void LoadFuel(Fuel fuel)
        {
            if (fuel.PerUse == Diesel.Efficiency) tank.Amount += fuel.Amount;
        }
    }

    public sealed class Enterprise : Vehicle
    {
        private Dilithium tank;

        public Enterprise()
        {
            tank = new Dilithium();
        }

        public bool Move()
        {
            if (tank.Amount > 0)
            {
                tank.Amount -= tank.PerUse;
                return true;
            }

            return false;
        }

        public void LoadFuel(Fuel fuel)
        {
            if (fuel.PerUse == Dilithium.Efficiency) tank.Amount += fuel.Amount;
        }
    }
}