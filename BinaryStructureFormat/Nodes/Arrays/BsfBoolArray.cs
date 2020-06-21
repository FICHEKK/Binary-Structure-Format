namespace BinaryStructureFormat.Nodes.Arrays
{
    public sealed class BsfBoolArray : BsfArray<bool>
    {
        public override BsfType Type => BsfType.BoolArray;

        public BsfBoolArray() => Array = EmptyArray;
        public BsfBoolArray(bool[] array) => Array = array;
        
        protected override void WriteSingleValue(ExtendedBinaryWriter writer, bool value) => writer.Write(value);
        protected override bool ReadSingleValue(ExtendedBinaryReader reader) => reader.ReadBoolean();
    }
}