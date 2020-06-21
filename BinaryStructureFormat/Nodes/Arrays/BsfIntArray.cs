namespace BinaryStructureFormat.Nodes.Arrays
{
    public sealed class BsfIntArray : BsfArray<int>
    {
        public override BsfType Type => BsfType.IntArray;

        public BsfIntArray() => Array = EmptyArray;
        public BsfIntArray(int[] array) => Array = array;

        protected override void WriteSingleValue(ExtendedBinaryWriter writer, int value) => writer.Write(value);
        protected override int ReadSingleValue(ExtendedBinaryReader reader) => reader.ReadInt32();
    }
}