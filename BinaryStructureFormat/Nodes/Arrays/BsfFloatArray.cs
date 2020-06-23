namespace BinaryStructureFormat.Nodes.Arrays
{
    /// <summary>
    /// Array node that stores an array of 32-bit single-precision floating point numbers.
    /// </summary>
    public sealed class BsfFloatArray : BsfArray<float>
    {
        /// <summary>
        /// Constructs a new node initialized with the default value of an empty array.
        /// </summary>
        public BsfFloatArray() => Array = EmptyArray;
        
        /// <summary>
        /// Constructs a new node initialized with the provided array.
        /// </summary>
        /// <param name="array">Initial array of this node.</param>
        public BsfFloatArray(float[] array) => Array = array;

        public override BsfType Type => BsfType.FloatArray;
        protected override void WriteSingleValue(ExtendedBinaryWriter writer, float value) => writer.Write(value);
        protected override float ReadSingleValue(ExtendedBinaryReader reader) => reader.ReadSingle();
    }
}