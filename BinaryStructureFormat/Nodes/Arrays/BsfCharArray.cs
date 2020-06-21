namespace BinaryStructureFormat.Nodes.Arrays
{
    public sealed class BsfCharArray : BsfArray<char>
    {
        public override BsfType Type => BsfType.CharArray;

        public BsfCharArray() => Array = EmptyArray;
        public BsfCharArray(char[] array) => Array = array;

        protected override void WriteSingleValue(ExtendedBinaryWriter writer, char value) => writer.Write(value);
        protected override char ReadSingleValue(ExtendedBinaryReader reader) => reader.ReadChar();
    }
}