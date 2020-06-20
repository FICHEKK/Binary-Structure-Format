using System.IO;

namespace BinaryStructureFormat.Nodes.Primitives
{
    public sealed class BsfInt : BsfNode
    {
        public override BsfType Type => BsfType.Int;
        public int Value { get; set; }
        
        public BsfInt() {}
        public BsfInt(int value) => Value = value;

        public override void WriteValue(BinaryWriter writer) => writer.Write(Value);
        public override void ReadValue(BinaryReader reader) => Value = reader.ReadInt32();
    }
}