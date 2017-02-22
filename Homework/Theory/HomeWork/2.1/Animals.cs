namespace _2._1
{
    using static System.Console;
    public interface Animal
    {
        void SaySomething();
    }

    public sealed class Cat : Animal
    {
        public void SaySomething() => WriteLine("Miao");
    }

    public sealed class Dog : Animal
    {
        public void SaySomething() => WriteLine("Bao");
    }

    public sealed class Cow : Animal
    {
        public void SaySomething() => WriteLine("Muuu");
    }
}