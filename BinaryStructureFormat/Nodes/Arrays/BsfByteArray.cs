namespace BinaryStructureFormat.Nodes.Arrays
{
    public sealed class BsfByteArray : BsfArray<byte>
    {
        public override BsfType Type => BsfType.ByteArray;

        public BsfByteArray() => Array = EmptyArray;
        public BsfByteArray(byte[] array) => Array = array;

        protected override void WriteSingleValue(ExtendedBinaryWriter writer, byte value) => writer.Write(value);
        protected override byte ReadSingleValue(ExtendedBinaryReader reader) => reader.ReadByte();
    }
}