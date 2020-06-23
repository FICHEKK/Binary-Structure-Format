using System;
using BinaryStructureFormat.Nodes.Arrays;
using BinaryStructureFormat.Nodes.Primitives;

namespace BinaryStructureFormat.Nodes
{
    /// <summary>
    /// Abstract node that serves as a base class for all of the concrete node implementations.
    /// </summary>
    public abstract class BsfNode
    {
        /// <summary>
        /// This node's type that defines the value(s) stored by this node.
        /// </summary>
        public abstract BsfType Type { get; }

        /// <summary>
        /// Writes the byte value of this node's type to the underlying stream.
        /// </summary>
        /// <param name="writer">Writer used for writing to the underlying stream.</param>
        public void WriteType(ExtendedBinaryWriter writer) => writer.Write((byte) Type);
        
        /// <summary>
        /// Writes the binary representation of the value stored by this node to the underlying stream.
        /// </summary>
        /// <param name="writer">Writer used for writing to the underlying stream.</param>
        public abstract void WriteValue(ExtendedBinaryWriter writer);
        
        /// <summary>
        /// Reads this node's value from the underlying stream.
        /// </summary>
        /// <param name="reader">Reader used for reading from the underlying stream.</param>
        public abstract void ReadValue(ExtendedBinaryReader reader);

        /// <summary>
        /// Parameterized factory method used to create a node of the given type.
        /// </summary>
        /// <param name="type">Type of the node that needs to be created.</param>
        /// <returns>A newly created node of provided type.</returns>
        protected static BsfNode Create(BsfType type)
        {
            return type switch
            {
                BsfType.Struct => (BsfNode) new BsfStruct(),
                BsfType.List => new BsfList(),
                BsfType.Null => null,
                
                BsfType.Byte => new BsfByte(),
                BsfType.Short => new BsfShort(),
                BsfType.Int => new BsfInt(),
                BsfType.Long => new BsfLong(),
                BsfType.Float => new BsfFloat(),
                BsfType.Double => new BsfDouble(),
                BsfType.Bool => new BsfBool(),
                BsfType.Char => new BsfChar(),
                BsfType.String => new BsfString(),
                
                BsfType.ByteArray => new BsfByteArray(),
                BsfType.ShortArray => new BsfShortArray(),
                BsfType.IntArray => new BsfIntArray(),
                BsfType.LongArray => new BsfLongArray(),
                BsfType.FloatArray => new BsfFloatArray(),
                BsfType.DoubleArray => new BsfDoubleArray(),
                BsfType.BoolArray => new BsfBoolArray(),
                BsfType.CharArray => new BsfCharArray(),
                BsfType.StringArray => new BsfStringArray(),
                
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}