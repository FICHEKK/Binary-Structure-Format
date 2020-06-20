using System;
using System.IO;

namespace BinaryStructureFormat.Nodes.Arrays
{
    public sealed class BsfLongArray : BsfNode
    {
        private static readonly long[] EmptyArray = new long[0];
        public override BsfType Type => BsfType.LongArray;

        private long[] _array;
        public long[] Array
        {
            get => _array;
            set => _array = value ?? throw new ArgumentNullException();
        }

        public BsfLongArray() => Array = EmptyArray;
        public BsfLongArray(long[] array) => Array = array;

        public override void WriteValue(BinaryWriter writer)
        {
            writer.Write(Array.Length);
            foreach (var value in Array)
                writer.Write(value);
        }

        public override void ReadValue(BinaryReader reader)
        {
            var count = reader.ReadInt32();
            Array = new long[count];

            for (var i = 0; i < count; i++)
                Array[i] = reader.ReadInt64();
        }
    }
}