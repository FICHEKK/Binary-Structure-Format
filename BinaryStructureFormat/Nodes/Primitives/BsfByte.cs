namespace BinaryStructureFormat.Nodes.Primitives
{
    /// <summary>
    /// Primitive node that stores a single unsigned 8-bit integer value.
    /// </summary>
    public sealed class BsfByte : BsfNode
    {
        /// <summary>
        /// Unsigned 8-bit integer value stored by this node.
        /// </summary>
        public byte Value { get; set; }
        
        /// <summary>
        /// Constructs a new node initialized with the default value.
        /// </summary>
        public BsfByte() {}
        
        /// <summary>
        /// Constructs a new node initialized with the provided value.
        /// </summary>
        /// <param name="value">Initial value of this node.</param>
        public BsfByte(byte value) => Value = value;

        public override BsfType Type => BsfType.Byte;
        public override void WriteValue(ExtendedBinaryWriter writer) => writer.Write(Value);
        public override void ReadValue(ExtendedBinaryReader reader) => Value = reader.ReadByte();
    }
}