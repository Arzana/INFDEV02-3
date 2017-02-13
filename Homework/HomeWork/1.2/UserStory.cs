namespace _1._2
{
    public sealed class UserStory
    {
        /* Writing full getter and setter methods or properties is useless
         * when all it does is set the values directly. */

        private byte hours;
        private string description;

        public byte GetHours() => hours;
        public string GetDescription => description;

        public byte SetHours(byte newH) => hours = newH;
        public string SetDescription(string newDesc) => description = newDesc;

        public override string ToString()
        {
            return $"{{ {hours} for task: {description} }}";
        }
    }
}