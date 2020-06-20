using System;
using System.IO;

namespace BinaryStructureFormat.Nodes.Arrays
{
    public sealed class BsfCharArray : BsfNode
    {
        private static readonly char[] EmptyArray = new char[0];
        public override BsfType Type => BsfType.CharArray;

        private char[] _array;
        public char[] Array
        {
            get => _array;
            set => _array = value ?? throw new ArgumentNullException();
        }

        public BsfCharArray() => Array = EmptyArray;
        public BsfCharArray(char[] array) => Array = array;

        public override void WriteValue(BinaryWriter writer)
        {
            writer.Write(Array.Length);
            foreach (var value in Array)
                writer.Write(value);
        }

        public override void ReadValue(BinaryReader reader)
        {
            var count = reader.ReadInt32();
            Array = reader.ReadChars(count);
        }
    }
}