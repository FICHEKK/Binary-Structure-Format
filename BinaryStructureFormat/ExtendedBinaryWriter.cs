using System.IO;

namespace BinaryStructureFormat
{
    public class ExtendedBinaryWriter : BinaryWriter
    {
        public ExtendedBinaryWriter(Stream stream) : base(stream) {}
        public new void Write7BitEncodedInt(int value) => base.Write7BitEncodedInt(value);
    }
}