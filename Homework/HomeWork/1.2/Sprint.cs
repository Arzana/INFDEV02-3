namespace _1._2
{
    using System;

    public sealed class Sprint
    {
        public UserStory[] Stories { get { return stories; } }
        private UserStory[] stories;

        public Sprint()
        {
            stories = new UserStory[0];
        }

        public void AddStory(UserStory story)
        {
            int len = Stories.Length;
            Array.Resize(ref stories, len + 1);
            stories[len] = story;
        }

        public int GetTotalHours()
        {
            int sum = 0;

            for (int i = 0; i < Stories.Length; i++)
            {
                sum += Stories[i].GetHours();
            }

            return sum;
        }

        public override string ToString()
        {
            return $"{{ TotalLength: {GetTotalHours()} }}";
        }
    }
}
