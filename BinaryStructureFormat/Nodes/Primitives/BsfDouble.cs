namespace BinaryStructureFormat.Nodes.Primitives
{
    public sealed class BsfDouble : BsfNode
    {
        public override BsfType Type => BsfType.Double;
        public double Value { get; set; }
        
        public BsfDouble() {}
        public BsfDouble(double value) => Value = value;

        public override void WriteValue(ExtendedBinaryWriter writer) => writer.Write(Value);
        public override void ReadValue(ExtendedBinaryReader reader) => Value = reader.ReadDouble();
    }
}