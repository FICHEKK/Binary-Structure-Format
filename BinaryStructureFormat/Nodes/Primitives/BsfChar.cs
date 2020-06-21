namespace BinaryStructureFormat.Nodes.Primitives
{
    public sealed class BsfChar : BsfNode
    {
        public override BsfType Type => BsfType.Char;
        public char Value { get; set; }
        
        public BsfChar() {}
        public BsfChar(char value) => Value = value;

        public override void WriteValue(ExtendedBinaryWriter writer) => writer.Write(Value);
        public override void ReadValue(ExtendedBinaryReader reader) => Value = reader.ReadChar();
    }
}