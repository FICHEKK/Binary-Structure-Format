namespace BinaryStructureFormat.Nodes.Arrays
{
    public sealed class BsfDoubleArray : BsfArray<double>
    {
        public override BsfType Type => BsfType.DoubleArray;

        public BsfDoubleArray() => Array = EmptyArray;
        public BsfDoubleArray(double[] array) => Array = array;

        protected override void WriteSingleValue(ExtendedBinaryWriter writer, double value) => writer.Write(value);
        protected override double ReadSingleValue(ExtendedBinaryReader reader) => reader.ReadDouble();
    }
}