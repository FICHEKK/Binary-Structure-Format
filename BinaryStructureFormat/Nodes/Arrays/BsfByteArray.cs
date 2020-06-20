using System;
using System.IO;

namespace BinaryStructureFormat.Nodes.Arrays
{
    public sealed class BsfByteArray : BsfNode
    {
        private static readonly byte[] EmptyArray = new byte[0];
        public override BsfType Type => BsfType.ByteArray;

        private byte[] _array;
        public byte[] Array
        {
            get => _array;
            set => _array = value ?? throw new ArgumentNullException();
        }

        public BsfByteArray() => Array = EmptyArray;
        public BsfByteArray(byte[] array) => Array = array;

        public override void WriteValue(BinaryWriter writer)
        {
            writer.Write(Array.Length);
            foreach (var value in Array)
                writer.Write(value);
        }

        public override void ReadValue(BinaryReader reader)
        {
            var count = reader.ReadInt32();
            Array = reader.ReadBytes(count);
        }
    }
}