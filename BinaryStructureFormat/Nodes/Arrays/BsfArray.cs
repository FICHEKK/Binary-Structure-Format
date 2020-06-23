using System;

namespace BinaryStructureFormat.Nodes.Arrays
{
    /// <summary>
    /// Base class for all of the array nodes.
    /// </summary>
    /// <typeparam name="T">Type of the elements in the array.</typeparam>
    public abstract class BsfArray<T> : BsfNode
    {
        /// <summary>
        /// Reusable reference to an empty array.
        /// </summary>
        protected static readonly T[] EmptyArray = new T[0];

        private T[] _array;
        
        /// <summary>
        /// Array stored by this node.
        /// </summary>
        public T[] Array
        {
            get => _array;
            set => _array = value ?? throw new ArgumentNullException();
        }

        /// <summary>
        /// Writes all of the elements contained in the array to the underlying stream, prefixed
        /// by the number of elements encoded using LEB128 encoding.
        /// </summary>
        /// <param name="writer">Writer used for writing to the underlying stream.</param>
        public override void WriteValue(ExtendedBinaryWriter writer)
        {
            writer.Write7BitEncodedInt(Array.Length);
            foreach (var value in Array)
                WriteSingleValue(writer, value);
        }

        /// <summary>
        /// Reads an array of elements from the underlying stream, where the number of
        /// elements is determined by the LEB128 encoded integer prefix.
        /// </summary>
        /// <param name="reader">Reader used for reading from the underlying stream.</param>
        public override void ReadValue(ExtendedBinaryReader reader)
        {
            var count = reader.Read7BitEncodedInt();
            Array = new T[count];

            for (var i = 0; i < count; i++)
                Array[i] = ReadSingleValue(reader);
        }

        /// <summary>
        /// Writes a single value to the underlying stream.
        /// </summary>
        /// <param name="writer">Writer used for writing to the underlying stream.</param>
        /// <param name="value">Value to be written to the stream.</param>
        protected abstract void WriteSingleValue(ExtendedBinaryWriter writer, T value);
        
        /// <summary>
        /// Reads and returns a single value from the underlying stream.
        /// </summary>
        /// <param name="reader">Reader used for reading from the underlying stream.</param>
        /// <returns>Value that was read from the underlying stream.</returns>
        protected abstract T ReadSingleValue(ExtendedBinaryReader reader);
    }
}