namespace Assignment.Interfaces
{
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;

    public interface IFactory : IComponent
    {
        Vector2 Position { get; }
        List<IContainer> ProductsToShip { get; }
        ITruck GetReadyTruck();
    }
}