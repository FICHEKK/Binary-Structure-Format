namespace BinaryStructureFormat.Nodes.Primitives
{
    public sealed class BsfBool : BsfNode
    {
        public override BsfType Type => BsfType.Bool;
        public bool Value { get; set; }
        
        public BsfBool() {}
        public BsfBool(bool value) => Value = value;

        public override void WriteValue(ExtendedBinaryWriter writer) => writer.Write(Value);
        public override void ReadValue(ExtendedBinaryReader reader) => Value = reader.ReadBoolean();
    }
}