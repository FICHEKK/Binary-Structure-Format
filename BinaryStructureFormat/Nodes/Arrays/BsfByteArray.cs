namespace BinaryStructureFormat.Nodes.Arrays
{
    /// <summary>
    /// Array node that stores an array of unsigned 8-bit integer values.
    /// </summary>
    public sealed class BsfByteArray : BsfArray<byte>
    {
        /// <summary>
        /// Constructs a new node initialized with the default value of an empty array.
        /// </summary>
        public BsfByteArray() => Array = EmptyArray;
        
        /// <summary>
        /// Constructs a new node initialized with the provided array.
        /// </summary>
        /// <param name="array">Initial array of this node.</param>
        public BsfByteArray(byte[] array) => Array = array;

        public override BsfType Type => BsfType.ByteArray;
        protected override void WriteSingleValue(ExtendedBinaryWriter writer, byte value) => writer.Write(value);
        protected override byte ReadSingleValue(ExtendedBinaryReader reader) => reader.ReadByte();
    }
}