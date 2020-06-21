namespace BinaryStructureFormat.Nodes.Arrays
{
    public sealed class BsfLongArray : BsfArray<long>
    {
        public override BsfType Type => BsfType.LongArray;

        public BsfLongArray() => Array = EmptyArray;
        public BsfLongArray(long[] array) => Array = array;

        protected override void WriteSingleValue(ExtendedBinaryWriter writer, long value) => writer.Write(value);
        protected override long ReadSingleValue(ExtendedBinaryReader reader) => reader.ReadInt64();
    }
}