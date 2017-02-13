namespace _1._3
{
    public sealed class UserStory
    {
        public byte hours;
        public string description;
        public Status status;

        public UserStory(byte hours, string description)
        {
            this.hours = hours;
            this.description = description;
            status = Status.ToDo;
        }

        public override string ToString()
        {
            return $"{{ {hours} for task: {description} }}";
        }

        public enum Status : byte
        {
            ToDo,
            InProgress,
            ToVerify,
            Done
        }
    }
}