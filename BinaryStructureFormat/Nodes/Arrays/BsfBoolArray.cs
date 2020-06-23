namespace BinaryStructureFormat.Nodes.Arrays
{
    /// <summary>
    /// Array node that stores an array of boolean values.
    /// </summary>
    public sealed class BsfBoolArray : BsfArray<bool>
    {
        /// <summary>
        /// Constructs a new node initialized with the default value of an empty array.
        /// </summary>
        public BsfBoolArray() => Array = EmptyArray;
        
        /// <summary>
        /// Constructs a new node initialized with the provided array.
        /// </summary>
        /// <param name="array">Initial array of this node.</param>
        public BsfBoolArray(bool[] array) => Array = array;
        
        public override BsfType Type => BsfType.BoolArray;
        protected override void WriteSingleValue(ExtendedBinaryWriter writer, bool value) => writer.Write(value);
        protected override bool ReadSingleValue(ExtendedBinaryReader reader) => reader.ReadBoolean();
    }
}