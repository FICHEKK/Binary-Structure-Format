namespace BinaryStructureFormat.Nodes.Primitives
{
    /// <summary>
    /// Primitive node that stores a single 64-bit double-precision floating point number.
    /// </summary>
    public sealed class BsfDouble : BsfNode
    {
        /// <summary>
        /// 64-bit double-precision floating point number stored by this node.
        /// </summary>
        public double Value { get; set; }
        
        /// <summary>
        /// Constructs a new node initialized with the default value.
        /// </summary>
        public BsfDouble() {}
        
        /// <summary>
        /// Constructs a new node initialized with the provided value.
        /// </summary>
        /// <param name="value">Initial value of this node.</param>
        public BsfDouble(double value) => Value = value;

        public override BsfType Type => BsfType.Double;
        public override void WriteValue(ExtendedBinaryWriter writer) => writer.Write(Value);
        public override void ReadValue(ExtendedBinaryReader reader) => Value = reader.ReadDouble();
    }
}