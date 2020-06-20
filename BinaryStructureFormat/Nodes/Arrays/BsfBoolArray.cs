using System;
using System.IO;

namespace BinaryStructureFormat.Nodes.Arrays
{
    public sealed class BsfBoolArray : BsfNode
    {
        private static readonly bool[] EmptyArray = new bool[0];
        public override BsfType Type => BsfType.BoolArray;
        
        private bool[] _array;
        public bool[] Array
        {
            get => _array;
            set => _array = value ?? throw new ArgumentNullException();
        }

        public BsfBoolArray() => Array = EmptyArray;
        public BsfBoolArray(bool[] array) => Array = array;

        public override void WriteValue(BinaryWriter writer)
        {
            writer.Write(Array.Length);
            foreach (var value in Array)
                writer.Write(value);
        }

        public override void ReadValue(BinaryReader reader)
        {
            var count = reader.ReadInt32();
            Array = new bool[count];

            for (var i = 0; i < count; i++)
                Array[i] = reader.ReadBoolean();
        }
    }
}