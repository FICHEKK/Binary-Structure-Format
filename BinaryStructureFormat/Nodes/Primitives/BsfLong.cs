﻿using System.IO;

namespace BinaryStructureFormat.Nodes.Primitives
{
    public sealed class BsfLong : BsfNode
    {
        public override BsfType Type => BsfType.Long;
        public long Value { get; set; }
        
        public BsfLong() {}
        public BsfLong(long value) => Value = value;

        public override void WriteValue(BinaryWriter writer) => writer.Write(Value);
        public override void ReadValue(BinaryReader reader) => Value = reader.ReadInt64();
    }
}