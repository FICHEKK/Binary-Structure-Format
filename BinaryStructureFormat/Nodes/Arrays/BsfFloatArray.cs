using System;
using System.IO;

namespace BinaryStructureFormat.Nodes.Arrays
{
    public sealed class BsfFloatArray : BsfNode
    {
        private static readonly float[] EmptyArray = new float[0];
        public override BsfType Type => BsfType.FloatArray;

        private float[] _array;
        public float[] Array
        {
            get => _array;
            set => _array = value ?? throw new ArgumentNullException();
        }

        public BsfFloatArray() => Array = EmptyArray;
        public BsfFloatArray(float[] array) => Array = array;

        public override void WriteValue(BinaryWriter writer)
        {
            writer.Write(Array.Length);
            foreach (var value in Array)
                writer.Write(value);
        }

        public override void ReadValue(BinaryReader reader)
        {
            var count = reader.ReadInt32();
            Array = new float[count];

            for (var i = 0; i < count; i++)
                Array[i] = reader.ReadSingle();
        }
    }
}