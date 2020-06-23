namespace BinaryStructureFormat.Nodes.Arrays
{
    /// <summary>
    /// Array node that stores an array of 64-bit double-precision floating point numbers.
    /// </summary>
    public sealed class BsfDoubleArray : BsfArray<double>
    {
        /// <summary>
        /// Constructs a new node initialized with the default value of an empty array.
        /// </summary>
        public BsfDoubleArray() => Array = EmptyArray;
        
        /// <summary>
        /// Constructs a new node initialized with the provided array.
        /// </summary>
        /// <param name="array">Initial array of this node.</param>
        public BsfDoubleArray(double[] array) => Array = array;

        public override BsfType Type => BsfType.DoubleArray;
        protected override void WriteSingleValue(ExtendedBinaryWriter writer, double value) => writer.Write(value);
        protected override double ReadSingleValue(ExtendedBinaryReader reader) => reader.ReadDouble();
    }
}