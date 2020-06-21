namespace BinaryStructureFormat.Nodes.Primitives
{
    public sealed class BsfFloat : BsfNode
    {
        public override BsfType Type => BsfType.Float;
        public float Value { get; set; }
        
        public BsfFloat() {}
        public BsfFloat(float value) => Value = value;

        public override void WriteValue(ExtendedBinaryWriter writer) => writer.Write(Value);
        public override void ReadValue(ExtendedBinaryReader reader) => Value = reader.ReadSingle();
    }
}