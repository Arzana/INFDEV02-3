namespace Assignment.Interfaces
{
    public interface IStateMachine : IUpdateable
    {
        bool Busy { get; }

        void Reset();
    }
}