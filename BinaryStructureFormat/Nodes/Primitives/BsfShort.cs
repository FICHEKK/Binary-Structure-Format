using System.IO;

namespace BinaryStructureFormat.Nodes.Primitives
{
    public sealed class BsfShort : BsfNode
    {
        public override BsfType Type => BsfType.Short;
        public short Value { get; set; }
        
        public BsfShort() {}
        public BsfShort(short value) => Value = value;

        public override void WriteValue(BinaryWriter writer) => writer.Write(Value);
        public override void ReadValue(BinaryReader reader) => Value = reader.ReadInt16();
    }
}