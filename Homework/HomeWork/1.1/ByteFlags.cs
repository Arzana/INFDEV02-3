namespace _1._1
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;

    [DebuggerDisplay("{ToString()}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ByteFlags : IEquatable<ByteFlags>
    {
        public byte val;

        public bool this[int i]
        {
            get
            {
                WithinRange(i);
                byte mask = (byte)(i > 0 ? 1 << i : 1);
                return (val & mask) != 0;
            }
            set
            {
                WithinRange(i);
                byte mask = (byte)(i > 0 ? 1 << i : 1);
                if (value) val |= mask;
                else val &= (byte)(~mask);
            }
        }

        public bool CheckSet(int i)
        {
            if (!this[i]) return this[i] = true;
            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ByteFlags other)
        {
            return val == other.val;
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(ByteFlags) ? Equals((ByteFlags)obj) : false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            return val;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 7; i >= 0; i--)
            {
                sb.Append(this[i] ? '1' : '0');
            }
            return sb.ToString();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void WithinRange(int i)
        {
            if (i > 7 || i < 0) throw new IndexOutOfRangeException();
        }
    }
}