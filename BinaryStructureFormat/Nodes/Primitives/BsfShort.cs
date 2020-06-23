namespace BinaryStructureFormat.Nodes.Primitives
{
    /// <summary>
    /// Primitive node that stores a single signed 16-bit integer value.
    /// </summary>
    public sealed class BsfShort : BsfNode
    {
        /// <summary>
        /// Signed 16-bit integer value stored by this node.
        /// </summary>
        public short Value { get; set; }
        
        /// <summary>
        /// Constructs a new node initialized with the default value.
        /// </summary>
        public BsfShort() {}
        
        /// <summary>
        /// Constructs a new node initialized with the provided value.
        /// </summary>
        /// <param name="value">Initial value of this node.</param>
        public BsfShort(short value) => Value = value;

        public override BsfType Type => BsfType.Short;
        public override void WriteValue(ExtendedBinaryWriter writer) => writer.Write(Value);
        public override void ReadValue(ExtendedBinaryReader reader) => Value = reader.ReadInt16();
    }
}