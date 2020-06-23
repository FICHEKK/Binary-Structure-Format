namespace BinaryStructureFormat.Nodes.Arrays
{
    /// <summary>
    /// Array node that stores an array of signed 32-bit integer values.
    /// </summary>
    public sealed class BsfIntArray : BsfArray<int>
    {
        /// <summary>
        /// Constructs a new node initialized with the default value of an empty array.
        /// </summary>
        public BsfIntArray() => Array = EmptyArray;
        
        /// <summary>
        /// Constructs a new node initialized with the provided array.
        /// </summary>
        /// <param name="array">Initial array of this node.</param>
        public BsfIntArray(int[] array) => Array = array;

        public override BsfType Type => BsfType.IntArray;
        protected override void WriteSingleValue(ExtendedBinaryWriter writer, int value) => writer.Write(value);
        protected override int ReadSingleValue(ExtendedBinaryReader reader) => reader.ReadInt32();
    }
}