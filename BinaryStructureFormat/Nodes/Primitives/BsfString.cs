using System;

namespace BinaryStructureFormat.Nodes.Primitives
{
    public sealed class BsfString : BsfNode
    {
        public override BsfType Type => BsfType.String;

        private string _value;
        public string Value
        {
            get => _value;
            set => _value = value ?? throw new ArgumentNullException();
        }

        public BsfString() => Value = string.Empty;
        public BsfString(string value) => Value = value;

        public override void WriteValue(ExtendedBinaryWriter writer) => writer.Write(Value);
        public override void ReadValue(ExtendedBinaryReader reader) => Value = reader.ReadString();
    }
}