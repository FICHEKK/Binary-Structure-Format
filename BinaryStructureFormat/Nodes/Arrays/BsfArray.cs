using System;

namespace BinaryStructureFormat.Nodes.Arrays
{
    public abstract class BsfArray<T> : BsfNode
    {
        protected static readonly T[] EmptyArray = new T[0];

        private T[] _array;
        public T[] Array
        {
            get => _array;
            set => _array = value ?? throw new ArgumentNullException();
        }

        public override void WriteValue(ExtendedBinaryWriter writer)
        {
            writer.Write7BitEncodedInt(Array.Length);
            foreach (var value in Array)
                WriteSingleValue(writer, value);
        }

        public override void ReadValue(ExtendedBinaryReader reader)
        {
            var count = reader.Read7BitEncodedInt();
            Array = new T[count];

            for (var i = 0; i < count; i++)
                Array[i] = ReadSingleValue(reader);
        }

        protected abstract void WriteSingleValue(ExtendedBinaryWriter writer, T value);
        protected abstract T ReadSingleValue(ExtendedBinaryReader reader);
    }
}