namespace _3._1
{
    #region BASE_COMPONENTS

    public interface Component { }

    public abstract class Engine : Component
    {
        public readonly int Cylinders;
        public readonly int HorsePower;

        protected Engine(int cyl, int hp)
        {
            Cylinders = cyl;
            HorsePower = hp;
        }

        public abstract float Turn(float fuel);
    }

    public abstract class GearBox : Component
    {
        public abstract float Turn(float engRpm);
    }

    public abstract class Wheels : Component
    {
        public readonly int Radius;

        protected Wheels(int r)
        {
            Radius = r;
        }

        public abstract float Turn(float gbRpm);
    }

    public abstract class FuelTank : Component
    {
        public readonly float Capacity;
        public float Amount;

        protected FuelTank(float cap)
        {
            Capacity = cap;
            Amount = cap;
        }

        public abstract float PumpFuel(float amount);
    }

    #endregion

    public abstract class Entity
    {
        protected Component[] Components { get; private set; }

        protected Entity(Component[] comp)
        {
            Components = comp;
        }

        protected T GetComp<T>(int i) => (T)Components[i];
    }

    public abstract class Car : Entity
    {
        public float DistanceTraveled { get; private set; }
        public float TankLevel { get { return Tank.Amount; } }

        protected Engine Engine { get { return GetComp<Engine>(0); } }
        protected GearBox GearBox { get { return GetComp<GearBox>(1); } }
        protected Wheels Wheels { get { return GetComp<Wheels>(2); } }
        protected FuelTank Tank { get { return GetComp<FuelTank>(3); } }

        protected Car(Engine eng, GearBox gb, Wheels wheels, FuelTank tank)
            : base(new Component[4] { eng, gb, wheels, tank }) { }

        public virtual void Update(float amount)
        {
            if (Tank.Amount > 0.0f)
            {
                float temp = Tank.PumpFuel(amount);
                temp = Engine.Turn(temp);
                temp = GearBox.Turn(temp);
                DistanceTraveled += Wheels.Turn(temp);
            }
        }
    }
}