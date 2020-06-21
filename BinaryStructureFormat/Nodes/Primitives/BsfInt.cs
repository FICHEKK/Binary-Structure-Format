namespace BinaryStructureFormat.Nodes.Primitives
{
    public sealed class BsfInt : BsfNode
    {
        public override BsfType Type => BsfType.Int;
        public int Value { get; set; }
        
        public BsfInt() {}
        public BsfInt(int value) => Value = value;

        public override void WriteValue(ExtendedBinaryWriter writer) => writer.Write(Value);
        public override void ReadValue(ExtendedBinaryReader reader) => Value = reader.ReadInt32();
    }
}