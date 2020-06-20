using System;
using System.IO;

namespace BinaryStructureFormat.Nodes.Arrays
{
    public sealed class BsfDoubleArray : BsfNode
    {
        private static readonly double[] EmptyArray = new double[0];
        public override BsfType Type => BsfType.DoubleArray;

        private double[] _array;
        public double[] Array
        {
            get => _array;
            set => _array = value ?? throw new ArgumentNullException();
        }

        public BsfDoubleArray() => Array = EmptyArray;
        public BsfDoubleArray(double[] array) => Array = array;

        public override void WriteValue(BinaryWriter writer)
        {
            writer.Write(Array.Length);
            foreach (var value in Array)
                writer.Write(value);
        }

        public override void ReadValue(BinaryReader reader)
        {
            var count = reader.ReadInt32();
            Array = new double[count];

            for (var i = 0; i < count; i++)
                Array[i] = reader.ReadDouble();
        }
    }
}