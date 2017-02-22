namespace _1._3
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public sealed class Sprint : IEnumerable<UserStory>
    {
        public List<UserStory> Stories { get { return stories; } }
        public readonly DateTime Start;
        public readonly TimeSpan Duration;

        private List<UserStory> stories;

        public Sprint()
            : this(DateTime.Now, TimeSpan.FromDays(7))
        { }

        public Sprint(DateTime start, TimeSpan duration)
        {
            Start = start;
            Duration = duration;
            stories = new List<UserStory>();
        }

        public static Sprint operator +(Sprint s, UserStory u) { s.stories.Add(u); return s; }

        public void Add(byte h, string d)
        {
            stories.Add(new UserStory(h, d));
        }

        public int GetHoursToDo()
        {
            int result = 0;

            for (int i = 0; i < stories.Count; i++)
            {
                if (stories[i].status != UserStory.Status.Done) result += stories[i].hours;
            }

            return result;
        }

        public int GetHoursDone()
        {
            int result = 0;

            for (int i = 0; i < stories.Count; i++)
            {
                if (stories[i].status == UserStory.Status.Done) result += stories[i].hours;
            }

            return result;
        }

        public bool IsDone()
        {
            if (DateTime.Now > Start + Duration) return true;

            for (int i = 0; i < stories.Count; i++)
            {
                if (stories[i].status != UserStory.Status.Done) return true;
            }

            return false;
        }

        public IEnumerator<UserStory> GetEnumerator()
        {
            return stories.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}