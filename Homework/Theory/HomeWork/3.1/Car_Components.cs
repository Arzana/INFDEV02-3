namespace _3._1
{
    public sealed class Mercedes500 : Engine
    {
        public const float FUEL_CONSUMTION = 3500;
        public static readonly Mercedes500 Instance = new Mercedes500();

        private Mercedes500()
            : base(12, 517) { }

        public override float Turn(float fuel) => FUEL_CONSUMTION * fuel;
    }

    public sealed class Mercedes722Comma6 : GearBox
    {
        public static readonly Mercedes722Comma6 Instance = new Mercedes722Comma6();

        private Mercedes722Comma6()
            : base() { }

        public override float Turn(float engRpm) => 7.5f * engRpm / (Mercedes500.FUEL_CONSUMTION * Wheels18Inch.Instance.Radius);
    }

    public sealed class Wheels18Inch : Wheels
    {
        public const float INCH2CM = 2.54f;
        public static readonly Wheels18Inch Instance = new Wheels18Inch();

        private Wheels18Inch()
            : base((int)(18 * INCH2CM)) { }

        public override float Turn(float gbRpm) => gbRpm * Radius;
    }

    public sealed class LargeTank : FuelTank
    {
        public LargeTank()
            : base(125) { }

        public override float PumpFuel(float amount) => Amount > amount ? Amount -= amount : Amount = 0.0f;
    }

    public sealed class Mercedes : Car
    {
        public Mercedes()
            : base(Mercedes500.Instance, Mercedes722Comma6.Instance, Wheels18Inch.Instance, new LargeTank())
        { }
    }
}