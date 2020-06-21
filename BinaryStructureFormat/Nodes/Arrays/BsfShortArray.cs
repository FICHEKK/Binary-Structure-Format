namespace BinaryStructureFormat.Nodes.Arrays
{
    public sealed class BsfShortArray : BsfArray<short>
    {
        public override BsfType Type => BsfType.ShortArray;

        public BsfShortArray() => Array = EmptyArray;
        public BsfShortArray(short[] array) => Array = array;

        protected override void WriteSingleValue(ExtendedBinaryWriter writer, short value) => writer.Write(value);
        protected override short ReadSingleValue(ExtendedBinaryReader reader) => reader.ReadInt16();
    }
}