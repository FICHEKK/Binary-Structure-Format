namespace BinaryStructureFormat.Nodes.Arrays
{
    /// <summary>
    /// Array node that stores an array of signed 64-bit integer values.
    /// </summary>
    public sealed class BsfLongArray : BsfArray<long>
    {
        /// <summary>
        /// Constructs a new node initialized with the default value of an empty array.
        /// </summary>
        public BsfLongArray() => Array = EmptyArray;
        
        /// <summary>
        /// Constructs a new node initialized with the provided array.
        /// </summary>
        /// <param name="array">Initial array of this node.</param>
        public BsfLongArray(long[] array) => Array = array;

        public override BsfType Type => BsfType.LongArray;
        protected override void WriteSingleValue(ExtendedBinaryWriter writer, long value) => writer.Write(value);
        protected override long ReadSingleValue(ExtendedBinaryReader reader) => reader.ReadInt64();
    }
}