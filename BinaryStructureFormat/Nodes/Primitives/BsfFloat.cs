namespace BinaryStructureFormat.Nodes.Primitives
{
    /// <summary>
    /// Primitive node that stores a single 32-bit single-precision floating point number.
    /// </summary>
    public sealed class BsfFloat : BsfNode
    {
        /// <summary>
        /// 32-bit single-precision floating point number stored by this node.
        /// </summary>
        public float Value { get; set; }
        
        /// <summary>
        /// Constructs a new node initialized with the default value.
        /// </summary>
        public BsfFloat() {}
        
        /// <summary>
        /// Constructs a new node initialized with the provided value.
        /// </summary>
        /// <param name="value">Initial value of this node.</param>
        public BsfFloat(float value) => Value = value;

        public override BsfType Type => BsfType.Float;
        public override void WriteValue(ExtendedBinaryWriter writer) => writer.Write(Value);
        public override void ReadValue(ExtendedBinaryReader reader) => Value = reader.ReadSingle();
    }
}