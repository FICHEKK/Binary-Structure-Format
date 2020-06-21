namespace BinaryStructureFormat.Nodes.Arrays
{
    public sealed class BsfFloatArray : BsfArray<float>
    {
        public override BsfType Type => BsfType.FloatArray;

        public BsfFloatArray() => Array = EmptyArray;
        public BsfFloatArray(float[] array) => Array = array;

        protected override void WriteSingleValue(ExtendedBinaryWriter writer, float value) => writer.Write(value);
        protected override float ReadSingleValue(ExtendedBinaryReader reader) => reader.ReadSingle();
    }
}