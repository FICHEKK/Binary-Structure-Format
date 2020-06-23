namespace BinaryStructureFormat.Nodes.Primitives
{
    /// <summary>
    /// Primitive node that stores a single boolean value.
    /// </summary>
    public sealed class BsfBool : BsfNode
    {
        /// <summary>
        /// Boolean value stored by this node.
        /// </summary>
        public bool Value { get; set; }
        
        /// <summary>
        /// Constructs a new node initialized with the default value.
        /// </summary>
        public BsfBool() {}
        
        /// <summary>
        /// Constructs a new node initialized with the provided value.
        /// </summary>
        /// <param name="value">Initial value of this node.</param>
        public BsfBool(bool value) => Value = value;

        public override BsfType Type => BsfType.Bool;
        public override void WriteValue(ExtendedBinaryWriter writer) => writer.Write(Value);
        public override void ReadValue(ExtendedBinaryReader reader) => Value = reader.ReadBoolean();
    }
}