namespace BinaryStructureFormat.Nodes.Primitives
{
    /// <summary>
    /// Primitive node that stores a single signed 64-bit integer value.
    /// </summary>
    public sealed class BsfLong : BsfNode
    {
        /// <summary>
        /// Signed 64-bit integer value stored by this node.
        /// </summary>
        public long Value { get; set; }
        
        /// <summary>
        /// Constructs a new node initialized with the default value.
        /// </summary>
        public BsfLong() {}
        
        /// <summary>
        /// Constructs a new node initialized with the provided value.
        /// </summary>
        /// <param name="value">Initial value of this node.</param>
        public BsfLong(long value) => Value = value;

        public override BsfType Type => BsfType.Long;
        public override void WriteValue(ExtendedBinaryWriter writer) => writer.Write(Value);
        public override void ReadValue(ExtendedBinaryReader reader) => Value = reader.ReadInt64();
    }
}