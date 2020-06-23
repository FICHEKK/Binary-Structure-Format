namespace BinaryStructureFormat.Nodes.Arrays
{
    /// <summary>
    /// Array node that stores an array of strings.
    /// </summary>
    public sealed class BsfStringArray : BsfArray<string>
    {
        /// <summary>
        /// Constructs a new node initialized with the default value of an empty array.
        /// </summary>
        public BsfStringArray() => Array = EmptyArray;
        
        /// <summary>
        /// Constructs a new node initialized with the provided array.
        /// </summary>
        /// <param name="array">Initial array of this node.</param>
        public BsfStringArray(string[] array) => Array = array;

        public override BsfType Type => BsfType.StringArray;
        protected override void WriteSingleValue(ExtendedBinaryWriter writer, string value) => writer.Write(value);
        protected override string ReadSingleValue(ExtendedBinaryReader reader) => reader.ReadString();
    }
}