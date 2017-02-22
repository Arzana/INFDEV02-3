namespace Assignment.Interfaces
{
    using Microsoft.Xna.Framework;

    public interface IContainer : IDrawable
    {
        int CurrentAmount { get; }
        int MaxCapacity { get; }
        Vector2 Position { get; set; }

        bool AddContent(int amount);
    }
}
