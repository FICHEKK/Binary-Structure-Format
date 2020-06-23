namespace BinaryStructureFormat.Nodes.Arrays
{
    /// <summary>
    /// Array node that stores an array of signed 16-bit integer values.
    /// </summary>
    public sealed class BsfShortArray : BsfArray<short>
    {
        /// <summary>
        /// Constructs a new node initialized with the default value of an empty array.
        /// </summary>
        public BsfShortArray() => Array = EmptyArray;
        
        /// <summary>
        /// Constructs a new node initialized with the provided array.
        /// </summary>
        /// <param name="array">Initial array of this node.</param>
        public BsfShortArray(short[] array) => Array = array;

        public override BsfType Type => BsfType.ShortArray;
        protected override void WriteSingleValue(ExtendedBinaryWriter writer, short value) => writer.Write(value);
        protected override short ReadSingleValue(ExtendedBinaryReader reader) => reader.ReadInt16();
    }
}