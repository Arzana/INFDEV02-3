namespace _2._1
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    public interface ListInt
    {
        /* The defined interface specifications are not clear.
         * The pdf states an interface of type 'ListInt' (assuming the interface needs to work with intergers)
         * yet this makes the interface useless because it will only work with one type.
         * The name of the interface needs to be changed to not include a type (change to generics) or it needs to be removed.
         * This also makes the map method weird because this will now return a IList instead of another instance of ListInt. */

        bool IsEmpty { get; }
        int Length { get; }

        void Iterate(Action<int> func);
        ListInt Filter(Func<int, bool> func);
        IList<T> Map<T>(Func<int, T> func);
    }

    public sealed class EmptyInt : ListInt
    {
        public bool IsEmpty { get { return true; } }
        public int Length { get { return 0; } }

        public void Iterate(Action<int> func) { }
        public ListInt Filter(Func<int, bool> func) { return this; }
        public IList<T> Map<T>(Func<int, T> func) { return new List<T>(); }
    }

    public sealed class NodeInt : ListInt, IDisposable
    {
        public bool IsEmpty { get { unsafe { return underlying == null; } } }
        public int Length
        {
            get
            {
                int len = 0;
                Iterate((v) => ++len);
                return len;
            }
        }

        private unsafe Node* underlying;

        public NodeInt()
        {
            unsafe { underlying = null; }
        }

        public NodeInt(params int[] coll)
            : this((IEnumerable<int>)coll)
        { }

        public NodeInt(IEnumerable<int> coll)
        {
            IEnumerator<int> iter = coll.GetEnumerator();
            bool first = true;

            unsafe
            {
                Node* cur = null;
                while (iter.MoveNext())
                {
                    if (first)
                    {
                        first = false;
                        underlying = CreateNode(iter.Current);
                        cur = underlying;
                    }
                    else
                    {
                        cur = CreateNode(iter.Current, cur);
                    }
                }
            }
        }

        ~NodeInt()
        {
            Dispose(true);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            unsafe
            {
                if (disposing) FreeNode(underlying);
                underlying = null;
            }
        }

        public void Add(int value)
        {
            unsafe
            {
                if (IsEmpty) underlying = CreateNode(value);
                else
                {
                    Node* n = underlying;
                    while (!n->IsLast) n = n->head;
                    CreateNode(value, n);
                }
            }
        }

        public void Iterate(Action<int> func)
        {
            if (IsEmpty) return;

            unsafe
            {
                Node* cur = underlying;
                do { func(cur->value); }
                while (!(cur = cur->head)->IsLast);
                func(cur->value);
            }
        }

        public ListInt Filter(Func<int, bool> func)
        {
            NodeInt result = new NodeInt();
            Iterate((v) => { if (func(v)) result.Add(v); });
            return result.IsEmpty ? (ListInt)new EmptyInt() : result;
        }

        public IList<T> Map<T>(Func<int, T> func)
        {
            List<T> result = new List<T>();
            Iterate((v) => result.Add(func(v)));
            return result;
        }

        public NodeInt Map(Func<int, int> func)
        {
            NodeInt result = new NodeInt();
            Iterate((v) => result.Add(func(v)));
            return result;
        }

        private unsafe Node* CreateNode(int value, Node* prev = null)
        {
            Node* n = (Node*)Marshal.AllocHGlobal(sizeof(Node));
            n->value = value;
            n->head = null;

            if (prev != null)
            {
                n->tail = prev;
                prev->head = n;
            }
            else n->tail = null;

            return n;
        }

        private unsafe void FreeNode(Node* node)
        {
            if (!node->IsLast) FreeNode(node->head);
            Marshal.FreeHGlobal((IntPtr)node);
        }

        private unsafe struct Node
        {
            public bool IsLast { get { return head == null; } }

            public int value;
            public Node* tail, head;
        }
    }
}