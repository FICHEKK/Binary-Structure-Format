using System;
using System.IO;
using BinaryStructureFormat.Nodes.Arrays;
using BinaryStructureFormat.Nodes.Primitives;

namespace BinaryStructureFormat.Nodes
{
    public abstract class BsfNode
    {
        public abstract BsfType Type { get; }

        public void WriteType(BinaryWriter writer) => writer.Write((byte) Type);
        public abstract void WriteValue(BinaryWriter writer);
        public abstract void ReadValue(BinaryReader reader);

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