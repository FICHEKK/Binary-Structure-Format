namespace BinaryStructureFormat.Nodes.Arrays
{
    public sealed class BsfStringArray : BsfArray<string>
    {
        public override BsfType Type => BsfType.StringArray;

        public BsfStringArray() => Array = EmptyArray;
        public BsfStringArray(string[] array) => Array = array;

        protected override void WriteSingleValue(ExtendedBinaryWriter writer, string value) => writer.Write(value);
        protected override string ReadSingleValue(ExtendedBinaryReader reader) => reader.ReadString();
    }
}