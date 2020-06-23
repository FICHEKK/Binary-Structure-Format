namespace BinaryStructureFormat.Nodes.Primitives
{
    /// <summary>
    /// Primitive node that stores a single signed 32-bit integer value.
    /// </summary>
    public sealed class BsfInt : BsfNode
    {
        /// <summary>
        /// Signed 32-bit integer value stored by this node.
        /// </summary>
        public int Value { get; set; }
        
        /// <summary>
        /// Constructs a new node initialized with the default value.
        /// </summary>
        public BsfInt() {}
        
        /// <summary>
        /// Constructs a new node initialized with the provided value.
        /// </summary>
        /// <param name="value">Initial value of this node.</param>
        public BsfInt(int value) => Value = value;

        public override BsfType Type => BsfType.Int;
        public override void WriteValue(ExtendedBinaryWriter writer) => writer.Write(Value);
        public override void ReadValue(ExtendedBinaryReader reader) => Value = reader.ReadInt32();
    }
}