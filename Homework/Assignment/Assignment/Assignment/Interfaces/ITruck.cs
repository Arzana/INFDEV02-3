namespace Assignment.Interfaces
{
    using Microsoft.Xna.Framework;

    public interface ITruck : IComponent
    {
        IContainer Container { get; }
        Vector2 Position { get; }
        Vector2 Velocity { get; }

        void StartEngine();
        void AddContainer(IContainer container);
    }
}
