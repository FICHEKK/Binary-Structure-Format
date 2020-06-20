using System;
using System.IO;

namespace BinaryStructureFormat.Nodes.Arrays
{
    public sealed class BsfShortArray : BsfNode
    {
        private static readonly short[] EmptyArray = new short[0];
        public override BsfType Type => BsfType.ShortArray;

        private short[] _array;
        public short[] Array
        {
            get => _array;
            set => _array = value ?? throw new ArgumentNullException();
        }

        public BsfShortArray() => Array = EmptyArray;
        public BsfShortArray(short[] array) => Array = array;

        public override void WriteValue(BinaryWriter writer)
        {
            writer.Write(Array.Length);
            foreach (var value in Array)
                writer.Write(value);
        }

        public override void ReadValue(BinaryReader reader)
        {
            var count = reader.ReadInt32();
            Array = new short[count];

            for (var i = 0; i < count; i++)
                Array[i] = reader.ReadInt16();
        }
    }
}