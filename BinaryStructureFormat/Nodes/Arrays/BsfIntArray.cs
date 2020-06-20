using System;
using System.IO;

namespace BinaryStructureFormat.Nodes.Arrays
{
    public sealed class BsfIntArray : BsfNode
    {
        private static readonly int[] EmptyArray = new int[0];
        public override BsfType Type => BsfType.IntArray;

        private int[] _array;
        public int[] Array
        {
            get => _array;
            set => _array = value ?? throw new ArgumentNullException();
        }

        public BsfIntArray() => Array = EmptyArray;
        public BsfIntArray(int[] array) => Array = array;

        public override void WriteValue(BinaryWriter writer)
        {
            writer.Write(Array.Length);
            foreach (var value in Array)
                writer.Write(value);
        }

        public override void ReadValue(BinaryReader reader)
        {
            var count = reader.ReadInt32();
            Array = new int[count];

            for (var i = 0; i < count; i++)
                Array[i] = reader.ReadInt32();
        }
    }
}