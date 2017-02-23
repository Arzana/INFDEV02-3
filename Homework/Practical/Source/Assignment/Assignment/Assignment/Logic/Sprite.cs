namespace Assignment.Logic
{
    using Microsoft.Xna.Framework;

    public interface ISprite
    {
        int Id { get; }
        Vector2 Position { get; }
        Vector2 Scale { get; }
    }

    public abstract class Sprite : ISprite
    {
        public int Id { get; private set; }
        public Vector2 Scale { get; private set; }
        public Vector2 Position { get; set; }

        protected Sprite(int id, Vector2 pos, Vector2 scale)
        {
            Id = id;
            Scale = scale;
            Position = pos;
        }
    }
}