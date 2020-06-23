namespace BinaryStructureFormat.Nodes.Arrays
{
    /// <summary>
    /// Array node that stores an array of Unicode UTF-16 characters.
    /// </summary>
    public sealed class BsfCharArray : BsfArray<char>
    {
        /// <summary>
        /// Constructs a new node initialized with the default value of an empty array.
        /// </summary>
        public BsfCharArray() => Array = EmptyArray;
        
        /// <summary>
        /// Constructs a new node initialized with the provided array.
        /// </summary>
        /// <param name="array">Initial array of this node.</param>
        public BsfCharArray(char[] array) => Array = array;

        public override BsfType Type => BsfType.CharArray;
        protected override void WriteSingleValue(ExtendedBinaryWriter writer, char value) => writer.Write(value);
        protected override char ReadSingleValue(ExtendedBinaryReader reader) => reader.ReadChar();
    }
}