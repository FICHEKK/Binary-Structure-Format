namespace BinaryStructureFormat.Nodes.Primitives
{
    /// <summary>
    /// Primitive node that stores a single Unicode UTF-16 character.
    /// </summary>
    public sealed class BsfChar : BsfNode
    {
        /// <summary>
        /// Unicode UTF-16 character stored by this node.
        /// </summary>
        public char Value { get; set; }
        
        /// <summary>
        /// Constructs a new node initialized with the default value.
        /// </summary>
        public BsfChar() {}
        
        /// <summary>
        /// Constructs a new node initialized with the provided value.
        /// </summary>
        /// <param name="value">Initial value of this node.</param>
        public BsfChar(char value) => Value = value;

        public override BsfType Type => BsfType.Char;
        public override void WriteValue(ExtendedBinaryWriter writer) => writer.Write(Value);
        public override void ReadValue(ExtendedBinaryReader reader) => Value = reader.ReadChar();
    }
}