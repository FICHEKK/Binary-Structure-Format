using System;
using System.IO;

namespace BinaryStructureFormat.Nodes.Arrays
{
    public sealed class BsfStringArray : BsfNode
    {
        private static readonly string[] EmptyArray = new string[0];
        public override BsfType Type => BsfType.StringArray;

        private string[] _array;
        public string[] Array
        {
            get => _array;
            set => _array = value ?? throw new ArgumentNullException();
        }

        public BsfStringArray() => Array = EmptyArray;
        public BsfStringArray(string[] array) => Array = array;

        public override void WriteValue(BinaryWriter writer)
        {
            writer.Write(Array.Length);
            foreach (var value in Array)
                writer.Write(value);
        }

        public override void ReadValue(BinaryReader reader)
        {
            var count = reader.ReadInt32();
            Array = new string[count];

            for (var i = 0; i < count; i++)
                Array[i] = reader.ReadString();
        }
    }
}