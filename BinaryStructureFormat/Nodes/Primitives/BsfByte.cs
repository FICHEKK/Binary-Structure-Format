namespace BinaryStructureFormat.Nodes.Primitives
{
    public sealed class BsfByte : BsfNode
    {
        public override BsfType Type => BsfType.Byte;
        public byte Value { get; set; }
        
        public BsfByte() {}
        public BsfByte(byte value) => Value = value;

        public override void WriteValue(ExtendedBinaryWriter writer) => writer.Write(Value);
        public override void ReadValue(ExtendedBinaryReader reader) => Value = reader.ReadByte();
    }
}